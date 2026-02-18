using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialTradingP
{
    public enum Trend { Upward, Downward, Sideways }
    public class PriceHistory<T> where T : IFinancialInstrument
    {
        private Dictionary<T, List<(DateTime timestamp, decimal price)>> _history
            = new();

        // Add price point
        public void AddPrice(T instrument, DateTime timestamp, decimal price)
        {
            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            if (!_history.ContainsKey(instrument))
                _history[instrument] = new List<(DateTime, decimal)>();

            _history[instrument].Add((timestamp, price));

            // Keep sorted by date
            _history[instrument] = _history[instrument]
                .OrderBy(p => p.timestamp)
                .ToList();
        }

        // Get Simple Moving Average (SMA)
        public decimal? GetMovingAverage(T instrument, int days)
        {
            if (days <= 0)
                throw new ArgumentException("Days must be positive.");

            if (!_history.ContainsKey(instrument))
                return null;

            var prices = _history[instrument]
                .OrderByDescending(p => p.timestamp)
                .Take(days)
                .Select(p => p.price)
                .ToList();

            if (prices.Count < days)
                return null;

            return prices.Average();
        }

        // Detect trend over given period
        public Trend DetectTrend(T instrument, int period)
        {
            if (period <= 1)
                throw new ArgumentException("Period must be greater than 1.");

            if (!_history.ContainsKey(instrument))
                return Trend.Sideways;

            var prices = _history[instrument]
                .OrderByDescending(p => p.timestamp)
                .Take(period)
                .Select(p => p.price)
                .Reverse()
                .ToList();

            if (prices.Count < period)
                return Trend.Sideways;

            decimal first = prices.First();
            decimal last = prices.Last();

            decimal changePercent = (last - first) / first * 100;

            if (changePercent > 2)       // > 2% growth
                return Trend.Upward;
            else if (changePercent < -2) // < -2% drop
                return Trend.Downward;
            else
                return Trend.Sideways;
        }
    }

}
