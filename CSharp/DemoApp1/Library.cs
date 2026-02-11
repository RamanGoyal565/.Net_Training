// TASK: Implement Indexer Overloading in C#
// Objective
// To understand and implement indexer overloading by allowing a class to be accessed using different parameter types.

// Scenario
// You are designing a Library Management System.
// Each book in the library has:
// A Book ID (integer)
// A Book Title (string)
// Users should be able to:
// Access books using Book ID
// Access books using Book Title
// This must be achieved using indexer overloading, not methods.

// Task Requirements
// You must create a class named Library and implement the following.

// PART 1: Internal Data Storage
// Use a suitable collection to store book data
// Book ID should be the key
// Book Title should be the value
// Data structure must be private

// PART 2: Integer-Based Indexer
// Requirement
// Allow access to book title using Book ID
// Support both reading and writing
// Example Usage
// library[101] = "C# Basics";
// Console.WriteLine(library[101]);


// PART 3: String-Based Indexer
// Requirement
// Allow access using Book Title
// Return the first matching title
// Read-only access only
// Example Usage
// Console.WriteLine(library["C# Basics"]);


// PART 4: Constraints
// Do not expose the internal collection directly
// Do not use GetBook() or SetBook() methods
// Use indexers only

// PART 5: Usage Task
// In Main():
// Create a Library object
// Add at least 3 books using integer indexer
// Retrieve books using both indexers
// Observe behavior when a title is not found


class Library
{
    private Dictionary<int,string> books=new Dictionary<int, string>();

    public string this[int bookId]
    {
        get
        {
            return books[bookId];
        }
        set
        {
            books[bookId]=value;
        }
    }
    public string this[string bookName]
    {
        get
        {
            return books.FirstOrDefault(b => b.Value==bookName).Value;
        }
    }
}