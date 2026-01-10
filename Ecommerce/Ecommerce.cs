namespace EcommerceAssessment
{
    public class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public List<T> GetAll()
        {
            return items;
        }
    }
    public delegate void OrderCallback(string message);
    public class Order
    {
        public int OrderId;
        public string CustomerName;
        public double Amount;
        public override string ToString()
        {
            return "OrderId: " + OrderId + ", Customer: " + CustomerName + ", Amount: " + Amount;
        }
    }
    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;
        public void ProcessOrder(
            Order order,
            Func<double, double> taxCalculator,
            Func<double, double> discountCalculator,
            Predicate<Order> validator,
            OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Order validation failed.");
                return;
            }
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);
            order.Amount = order.Amount + tax - discount;
            callback("Order " + order.OrderId + " processed successfully.");
            if (OrderProcessed != null)
            {
                OrderProcessed("Event: Order " + order.OrderId + " completed.");
            }
        }
    }
}