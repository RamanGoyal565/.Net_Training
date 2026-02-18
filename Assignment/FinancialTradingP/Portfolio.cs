using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialTradingP
{
    public interface IFinancialInstrument
    {
        string Symbol { get; }
        decimal CurrentPrice { get; }
        InstrumentType Type { get; }
    }

    public enum InstrumentType { Stock, Bond, Option, Future }
    public class Portfolio<T> where T : IFinancialInstrument
    {
        
        private Dictionary<T, int> _holdings = new();
        public void Buy(T instrument, int quantity, decimal price)
        {
            if (quantity <= 0 || price <= 0)
                throw new ArgumentException("Invalid quantity or price.");

            if (!_holdings.ContainsKey(instrument))
                _holdings[instrument] = 0;

            _holdings[instrument] += quantity;
        }
        public decimal? Sell(T instrument, int quantity, decimal currentPrice)
        {
            if (!_holdings.ContainsKey(instrument) ||
                _holdings[instrument] < quantity)
                return null;

            _holdings[instrument] -= quantity;

            return quantity * currentPrice;
        }
        public decimal CalculateTotalValue()
        {
            return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
        }
        public (T instrument, decimal returnPercentage)? GetTopPerformer(
            Dictionary<T, decimal> purchasePrices)
        {
            var performances = _holdings
                .Where(h => purchasePrices.ContainsKey(h.Key))
                .Select(h =>
                {
                    var purchase = purchasePrices[h.Key];
                    var current = h.Key.CurrentPrice;
                    var returnPct = (current - purchase) / purchase * 100;
                    return (h.Key, returnPct);
                });

            if (!performances.Any())
                return null;

            return performances.OrderByDescending(p => p.returnPct).First();
        }
    }
}