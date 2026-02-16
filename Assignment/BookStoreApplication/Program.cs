using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO:
            // 1. Read initial input
            // Format: BookID Title Price Stock
            string[] input = Console.ReadLine().Split(" ");
            Book book = new Book();
            book.Id = input[0];
            book.Title = input[1];
            book.Price = int.Parse(input[2]);
            book.Stock = int.Parse(input[3]);
            BookUtility utility = new BookUtility(book);

            while (true)
            {
                // TODO:
                // Display menu:
                // 1 -> Display book details
                // 2 -> Update book price
                // 3 -> Update book stock
                // 4 -> Exit

                int choice = 0; // TODO: Read user choice
                
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            utility.GetBookDetails();
                            break;

                        case 2:
                            // TODO:
                            // Read new price
                            // Call UpdateBookPrice()
                            int newPrice = int.Parse(Console.ReadLine());
                            utility.UpdateBookPrice(newPrice);
                            break;

                        case 3:
                            // TODO:
                            // Read new stock
                            // Call UpdateBookStock()
                            int newStock = int.Parse(Console.ReadLine());
                            utility.UpdateBookStock(newStock);
                            break;

                        case 4:
                            Console.WriteLine("Thank You");
                            return;

                        default:
                            // TODO: Handle invalid choice
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                }
                catch(InvalidBookDataExecption ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();
        }
    }
}