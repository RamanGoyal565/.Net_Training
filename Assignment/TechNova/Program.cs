using System;
namespace Inventory_Management_System
{
    class Program
    {
        public static void Main()
        {
            try
            {
                Grocery grocery = new Grocery()
                {
                    Name = "Milk",
                    Price = 35,
                    ExpiryDate = new DateTime(2026, 02, 16),
                    Weight = 0.5,
                    IsOrganic = true,
                    StorageTemperature = 0
                };

                grocery.Verify();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Clothing clothing = new Clothing()
                {
                    Name = "Jacket",
                    Price = 500,
                    Size = "L",           
                    FabricType = "Leather",
                    Gender = "Non-Specified", 
                    Color = "Black"
                };

                clothing.Verify();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
