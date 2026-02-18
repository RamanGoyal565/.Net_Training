using FinancialTradingP;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        // a) Create instruments
        var stock1 = new Stock
        {
            Symbol = "AAPL",
            CurrentPrice = 180,
            CompanyName = "Apple Inc.",
            DividendYield = 0.6m
        };

        var stock2 = new Stock
        {
            Symbol = "MSFT",
            CurrentPrice = 350,
            CompanyName = "Microsoft",
            DividendYield = 0.8m
        };

        var bond1 = new Bond
        {
            Symbol = "US10Y",
            CurrentPrice = 1000,
            CouponRate = 2.5m,
            MaturityDate = DateTime.Today.AddYears(10)
        };

        // b) Portfolio
        var portfolio = new Portfolio<IFinancialInstrument>();

        portfolio.Buy(stock1, 10, 150);
        portfolio.Buy(stock2, 5, 300);
        portfolio.Buy(bond1, 2, 950);

        Console.WriteLine("Initial Portfolio Value: " + portfolio.CalculateTotalValue());

        // c) Sell example
        var proceeds = portfolio.Sell(stock1, 5, stock1.CurrentPrice);
        Console.WriteLine("Sold AAPL for: " + proceeds);

        Console.WriteLine("Updated Portfolio Value: " + portfolio.CalculateTotalValue());

        // d) Performance comparison
        var purchasePrices = new Dictionary<IFinancialInstrument, decimal>
        {
            { stock1, 150 },
            { stock2, 300 },
            { bond1, 950 }
        };

        var top = portfolio.GetTopPerformer(purchasePrices);

        if (top != null)
        {
            Console.WriteLine(
                $"Top Performer: {top?.instrument.Symbol} " +
                $"Return: {top?.returnPercentage:F2}%");
        }

        // e) Price history and trend
        var history = new PriceHistory<Stock>();

        history.AddPrice(stock1, DateTime.Today.AddDays(-3), 170);
        history.AddPrice(stock1, DateTime.Today.AddDays(-2), 175);
        history.AddPrice(stock1, DateTime.Today.AddDays(-1), 178);
        history.AddPrice(stock1, DateTime.Today, 180);

        var movingAvg = history.GetMovingAverage(stock1, 3);
        Console.WriteLine("3-Day Moving Average: " + movingAvg);

        var trend = history.DetectTrend(stock1, 3);
        Console.WriteLine("Trend Detected: " + trend);
    }
}
