namespace Inventory_Management_System
{
    abstract class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public abstract void Verify();
    }
}