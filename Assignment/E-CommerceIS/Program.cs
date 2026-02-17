using E_CommerceIS;

class Program
{
    public static void Main()
    {
        var electronicsRepo = new ProductRepository<ElectronicProduct>();

        try
        {
            // Create electronic products
            var laptop = new ElectronicProduct
            {
                Id = 1,
                Name = "Gaming Laptop",
                Price = 1500m,
                WarrantyMonths = 24,
                Brand = "Dell"
            };

            var tv = new ElectronicProduct
            {
                Id = 2,
                Name = "4K Smart TV",
                Price = 900m,
                WarrantyMonths = 36,
                Brand = "Samsung"
            };

            var headphones = new ElectronicProduct
            {
                Id = 3,
                Name = "Noise Cancelling Headphones",
                Price = 300m,
                WarrantyMonths = 12,
                Brand = "Sony"
            };

            var smartphone = new ElectronicProduct
            {
                Id = 4,
                Name = "Flagship Smartphone",
                Price = 1100m,
                WarrantyMonths = 12,
                Brand = "Samsung"
            };

            var tablet = new ElectronicProduct
            {
                Id = 5,
                Name = "Business Tablet",
                Price = 650m,
                WarrantyMonths = 18,
                Brand = "Microsoft"
            };

            // ✅ Add products with validation
            electronicsRepo.AddProduct(laptop);
            electronicsRepo.AddProduct(tv);
            electronicsRepo.AddProduct(headphones);
            electronicsRepo.AddProduct(smartphone);
            electronicsRepo.AddProduct(tablet);

            Console.WriteLine("All electronics added successfully.\n");

            // ❌ Attempt duplicate ID
            try
            {
                electronicsRepo.AddProduct(new ElectronicProduct
                {
                    Id = 1,
                    Name = "Duplicate Product",
                    Price = 100,
                    Brand = "Test"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Duplicate ID Test: {ex.Message}\n");
            }

            // ✅ Calculate total inventory value
            Console.WriteLine($"Total Inventory Value: {electronicsRepo.CalculateTotalValue()}\ns");

            // ✅ Find products by brand
            var samsungProducts = electronicsRepo.FindProducts(p => p.Brand == "Samsung");

            Console.WriteLine("Samsung Products:");
            foreach (var product in samsungProducts)
            {
                Console.WriteLine($" - {product.Name} ({product.Price})");
            }

            Console.WriteLine();

            // ✅ Apply 15% discount to Laptop
            var discountedLaptop = new DiscountedProduct<ElectronicProduct>(laptop, 15);
            Console.WriteLine("Discount Example:");
            Console.WriteLine(discountedLaptop);
            Console.WriteLine();

            // ✅ Inventory Manager Processing
            var manager = new InventoryManager();
            manager.ProcessProducts(electronicsRepo.GetAll());

            Console.WriteLine();

            // ✅ Bulk price increase (10%)
            manager.UpdatePrices(
                electronicsRepo.GetAll(),
                p => p.Price * 1.10m
            );

            Console.WriteLine($"Total After 10% Increase: {electronicsRepo.CalculateTotalValue()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}