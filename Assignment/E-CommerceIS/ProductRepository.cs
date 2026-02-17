using System;
using System.Collections.Generic;
using System.Text;

namespace E_CommerceIS
{
    public interface IProduct
    {
        int Id { get; }
        string Name { get; }
        decimal Price { get; }
        Category Category { get; }
    }
    public enum Category { Electronics, Clothing, Books, Groceries }
    public class ProductRepository<T> where T : class, IProduct
    {
        private List<T> _products = new List<T>();

        // TODO: Implement method to add product with validation
        public void AddProduct(T product)
        {
            if (product == null)
                throw new Exception("No Product");
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new Exception("Name cannot be empty");
            if (product.Price < 0)
                throw new Exception("Price cannot be less than zero");
            if (_products.Any(p => p.Id == product.Id))
                throw new Exception("Duplicate product");
            _products.Add(product);
            // Rule: Product ID must be unique
            // Rule: Price must be positive
            // Rule: Name cannot be null or empty
            // Add to collection if validation passes
        }

        // TODO: Create method to find products by predicate
        public IEnumerable<T> FindProducts(Func<T, bool> predicate)
        {
            // Should return filtered products
            return _products.Where(predicate);
        }

        // TODO: Calculate total inventory value
        public decimal CalculateTotalValue()
        {
            // Return sum of all product prices
            return _products.Sum(p => p.Price);
        }
        public List<T> GetAll()
        {
            return _products;
        }
    }

    // 2. Specialized electronic product
    public class ElectronicProduct : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category => Category.Electronics;
        public int WarrantyMonths { get; set; }
        public string Brand { get; set; }
    }

    // 3. Create a discounted product wrapper
    public class DiscountedProduct<T> where T : IProduct
    {
        private T _product;
        private decimal _discountPercentage;

        public DiscountedProduct(T product, decimal discountPercentage)
        {
            // TODO: Initialize with validation
            // Discount must be between 0 and 100
            
            if (discountPercentage > 100 || discountPercentage < 0)
                throw new Exception("Invalid Discount percentage");
            _product = product??throw new Exception("No Product");
            _discountPercentage = discountPercentage;
        }

        // TODO: Implement calculated price with discount
        public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

        // TODO: Override ToString to show discount details
        public override string ToString()
        {
            return $"{_product.Name} - {_product.Price } - {_discountPercentage} - {DiscountedPrice}";
        }
    }

    // 4. Inventory manager with constraints
    public class InventoryManager
    {
        // TODO: Create method that accepts any IProduct collection
        public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
        {
            // a) Print all product names and prices
            // b) Find the most expensive product
            // c) Group products by category
            // d) Apply 10% discount to Electronics over $500
            if (products == null)
                throw new Exception("No Products");
            foreach(T product in products)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }
            Console.WriteLine("Most Expensive product:"+products.Max(p => p.Price));
            var groupProduct = products.GroupBy(p => p.Category);
            foreach (var group in groupProduct)
            {
                Console.WriteLine("Category:" + group.Key);
                foreach (var product in group)
                    Console.WriteLine($"- {product.Name}");
            }

            var discounted = products.Where(p=>p.Category==Category.Electronics && p.Price>=500)
            .Select(p => new DiscountedProduct<IProduct>(p, 10));
            foreach (var d in discounted)
                Console.WriteLine(d);
        }

        // TODO: Implement bulk price update with delegate
        public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
            where T : IProduct
        {

            // Apply priceAdjuster to each product
            // Handle exceptions gracefully
            if (products == null || priceAdjuster == null)
                throw new Exception("Products or Price Adjuster cannot be null");

            foreach (var product in products)
            {
                try
                {
                    var newPrice = priceAdjuster(product);

                    if (newPrice <= 0)
                        throw new InvalidOperationException("Adjusted price must be positive.");
                    // Reflection used to update price (since interface has no setter)
                    var prop = product.GetType().GetProperty("Price");
                    if (prop != null && prop.CanWrite)
                        prop.SetValue(product, newPrice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to update {product.Name}: {ex.Message}");
                }
            }
        }
    }
}