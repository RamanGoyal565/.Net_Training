using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialTradingP
{
    public class Stock : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Stock;
        public string CompanyName { get; set; }
        public decimal DividendYield { get; set; }
    }
    public class Bond : IFinancialInstrument
    {
        public string Symbol { get; set; }
        public decimal CurrentPrice { get; set; }
        public InstrumentType Type => InstrumentType.Bond;
        public DateTime MaturityDate { get; set; }
        public decimal CouponRate { get; set; }
    }
    public class TradingStrategy<T> where T : IFinancialInstrument
    {
        // Execute trading strategy on portfolio
        public void Execute(
            Portfolio<T> portfolio,
            IEnumerable<T> marketData,
            Func<T, bool> buyCondition,
            Func<T, bool> sellCondition)
        {
            foreach (var instrument in marketData)
            {
                // Buy condition
                if (buyCondition(instrument))
                {
                    portfolio.Buy(instrument, 1, instrument.CurrentPrice);
                }

                // Sell condition
                if (sellCondition(instrument))
                {
                    portfolio.Sell(instrument, 1, instrument.CurrentPrice);
                }
            }
        }

        // Calculate simplified risk metrics
        public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
        {
            var prices = instruments.Select(i => i.CurrentPrice).ToList();

            if (!prices.Any())
            {
                return new Dictionary<string, decimal>
            {
                { "Volatility", 0 },
                { "Beta", 0 },
                { "Sharpe Ratio", 0 }
            };
            }

            // --- Volatility (Standard Deviation of Prices) ---
            decimal average = prices.Average();
            decimal variance = prices
                .Select(p => (p - average) * (p - average))
                .Average();

            decimal volatility = (decimal)Math.Sqrt((double)variance);

            // --- Beta (Simplified mock calculation) ---
            // In real trading this compares against market index
            decimal beta = volatility != 0 ? volatility / average : 0;

            // --- Sharpe Ratio (Simplified) ---
            decimal riskFreeRate = 0.02m; // assumed 2%
            decimal expectedReturn = (average - prices.Min()) / prices.Min();

            decimal sharpeRatio =
                volatility != 0
                ? (expectedReturn - riskFreeRate) / volatility
                : 0;

            return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta", beta },
            { "Sharpe Ratio", sharpeRatio }
        };
        }
    }

}
