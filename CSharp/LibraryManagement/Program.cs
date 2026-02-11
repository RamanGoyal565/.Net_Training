using System;
//Task 5 Namespace
using LibraryAlias=LibrarySystem;
using ItemAlias = LibrarySystem.Items;
using UserAlias=LibrarySystem.Users;
class Program
{
    public static void Main(String[] args)
    {
        //Task 5 Namespace
        ItemAlias.Book book = new ItemAlias.Book
        {
            Title = "C# Fundamentals",
            Author = "John Doe",
            ItemID = 101
        };
        ItemAlias.Magazine magazine = new ItemAlias.Magazine
        {
            Title = "Tech Today",
            Author = "Jane Doe",
            ItemID = 201
        };
        Console.WriteLine("Book and Magazine objects created using namespace alias.");
        
        //Task 1 Abstract Class
        book.Display();
        Console.WriteLine($"Late Fee for 3 days: {book.LateFee(3)}");
        magazine.Display();
        Console.WriteLine($"Late Fee for 3 days: {magazine.LateFee(3)}");
        
        //Task 2 Iterface
        book.Reserve();
        book.Notify("Your book is ready for pickup.");     
        
        //Task 4 Explicit Interface
        LibraryAlias.IReservable reservableBook = book;
        LibraryAlias.INotifiable notifiableBook = book;
        reservableBook.Reserve();
        notifiableBook.Notify("Your reserved book is ready for pickup.");
        
        //Task 3 Dynamic Polymorphism
        LibraryAlias.LibraryItem[] items = { book, magazine };
        foreach (LibraryAlias.LibraryItem item in items)
        {
            item.Display();
        }
        Console.WriteLine(
            "The method executed depends on the object type at runtime, not the reference type."
        );
        
        //Task 6 Partial Class
        LibraryAnalytics.BorrowedItems += 5;
        LibraryAnalytics.Display();
        UsersAlias.Users.Member user = new UsersAlias.Users.Member
        {
            Name = "Alice",
            Role = LibraryAlias.UserRole.Member
        };
        
        //Task 7 Enums
        UsersAlias.ItemStatus status = UsersAlias.ItemStatus.Borrowed;
        Console.WriteLine($"User Role: {user.Role}");
        Console.WriteLine($"Item Status: {status}");
    }
}