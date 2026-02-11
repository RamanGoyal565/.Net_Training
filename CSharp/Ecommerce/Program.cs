using System;
using System.Collections.Generic;
using EcommerceAssessment;
using System.Reflection;
class Program
{
    static void Main()
    {
        Repository<Order> orderRepository = new Repository<Order>();
        orderRepository.Add(new Order { OrderId = 1, CustomerName = "Alice", Amount = 1500 });   // medium
        orderRepository.Add(new Order { OrderId = 2, CustomerName = "Bob", Amount = 300 });      // low
        orderRepository.Add(new Order { OrderId = 3, CustomerName = "Charlie", Amount = 4000 }); // high
        Func<double, double> taxCalculator = amount => amount * 0.18;
        Func<double, double> discountCalculator = amount => amount * 0.10;
        Predicate<Order> validator = order => order.Amount >= 500;
        OrderCallback callback = message =>
        {
            Console.WriteLine("Callback: " + message);
        };
        Action<string> logger = message =>
        {
            Console.WriteLine("Logger: " + message);
        };
        Action<string> notifier = message =>
        {
            Console.WriteLine("Notifier: " + message);
        };
        Action<string> multicast = logger + notifier;
        OrderProcessor processor = new OrderProcessor();
        processor.OrderProcessed += multicast;
        foreach (Order order in orderRepository.GetAll())
        {
            processor.ProcessOrder(
                order,
                taxCalculator,
                discountCalculator,
                validator,
                callback
            );
        }
        List<Order> orders = orderRepository.GetAll();
        orders.Sort((x, y) => y.Amount.CompareTo(x.Amount));
       Console.WriteLine("\nSorted Orders (Descending Amount):");
        foreach (Order order in orders)
        {
            Console.WriteLine(order.ToString());
        }
    }
}