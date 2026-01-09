using System;
using System.Collections.Generic;
using EcommerceAssessment;

class Program
{
    static void Main()
    {
        Repository<string> productRepository = new Repository<string>();
        productRepository.Add("Laptop");
        productRepository.Add("Tablet");

        List<string> products = productRepository.GetAll();
        foreach (string product in products)
        {
            Console.WriteLine(product);
        }

        Order order1 = new Order();
        order1.OrderId = 101;
        order1.CustomerName = "Alice";
        order1.Amount = 5000;

        Console.WriteLine(order1.ToString());

        OrderCallback callback = CallbackHandler;

        callback("Order validation failed.");

        OrderProcessor processor = new OrderProcessor();

        Action<string> logger = LoggerHandler;
        Action<string> notifier = NotifierHandler;

        Action<string> multicast = logger + notifier;
        processor.OrderProcessed += multicast;

        Predicate<Order> validator = ValidateOrder;
        Func<double, double> taxCalculator = CalculateTax;
        Func<double, double> discountCalculator = CalculateDiscount;

        processor.ProcessOrder(order1, taxCalculator, discountCalculator, validator, callback);

        Order order2 = new Order();
        order2.OrderId = 102;
        order2.CustomerName = "Bob";
        order2.Amount = 200;

        processor.ProcessOrder(order2, taxCalculator, discountCalculator, validator, callback);

        List<Order> orders = new List<Order>();

        Order o1 = new Order();
        o1.OrderId = 1;
        o1.CustomerName = "Alice";
        o1.Amount = 5900;

        Order o2 = new Order();
        o2.OrderId = 2;
        o2.CustomerName = "Bob";
        o2.Amount = 2360;

        Order o3 = new Order();
        o3.OrderId = 3;
        o3.CustomerName = "Charlie";
        o3.Amount = 9440;

        orders.Add(o1);
        orders.Add(o2);
        orders.Add(o3);

        orders.Sort(CompareOrders);

        foreach (Order order in orders)
        {
            Console.WriteLine(order.ToString());
        }
    }

    static void CallbackHandler(string message)
    {
        Console.WriteLine("Callback: " + message);
    }

    static void LoggerHandler(string message)
    {
        Console.WriteLine("Logger: " + message);
    }

    static void NotifierHandler(string message)
    {
        Console.WriteLine("Notifier: " + message);
    }

    static bool ValidateOrder(Order order)
    {
        return order.Amount >= 500;
    }

    static double CalculateTax(double amount)
    {
        return amount * 0.18;
    }

    static double CalculateDiscount(double amount)
    {
        return amount * 0.10;
    }

    static int CompareOrders(Order x, Order y)
    {
        return y.Amount.CompareTo(x.Amount);
    }
}