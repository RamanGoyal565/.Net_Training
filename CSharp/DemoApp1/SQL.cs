class Customer
{
    public int Customer_Id{get;set;}
    public string First_name{get;set;}
    public string Last_name{get;set;}
    public long Phone{get;set;}
    public string Email{get;set;}
    public string City{get;set;}
    public string State{get;set;}
    public long Zip_Code{get;set;}
    public List<Order> ?order; 
}
enum OrderStatus
{
    Delivered,Cancelled,Shipped,Return,Pending
}
class Order
{
    public int OrderId{get;set;}
    public Customer ?CustomerId{get;set;}
    public OrderStatus OrderStatus{get;set;}
    public DateTime OrderDate{get;set;}
    public DateTime RequiredDate{get;set;}
    public DateTime ShippedDate{get;set;}
    public Store StoreId{get;set;}
    public Staff StaffId{get;set;}
    public OrderItem? orderItem{get;set;}
}
class Store
{
    public int Store_Id{get;set;}
    public string Store_name{get;set;}
    public long Phone{get;set;}
    public string Email{get;set;}
    public string Street{get;set;}
    public string City{get;set;}
    public string State{get;set;}
    public long Zip_Code{get;set;}
    public List<Order>? order;
    public List<Staff>? staff; 
}
class Staff
{
    public int Staff_Id{get;set;}
    public string First_name{get;set;}
    public string Last_name{get;set;}
    public long Phone{get;set;}
    public string Email{get;set;}
    public bool Active{get;set;}
    public Store Store_Id{get;set;}
    public Staff ?Manager_Id{get;set;}
    public List<Staff>? subordinates;
    public List<Order>? order;    
}
class OrderItem
{
    public Order OrderId { get; set; }
    public int ItemId { get; set; }
    public int ProductId { get; set; }
    public int QuantityId { get; set; }
    public double ListPrice { get; set; }
    public double Discount { get; set; }
}
