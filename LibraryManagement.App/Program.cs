using LibraryManagement.Service.Models;
using LibraryManagement.Service.Services;

var service = new BookService();

while (true)
{
    Console.Clear();
    Console.WriteLine("====================================");
    Console.WriteLine("       Library Management System");
    Console.WriteLine("====================================");
    Console.WriteLine("1. Add Book");
    Console.WriteLine("2. Update Book");
    Console.WriteLine("3. Delete Book");
    Console.WriteLine("4. List All Books");
    Console.WriteLine("5. View Book Details");
    Console.WriteLine("6. Exit");
    Console.Write("Select option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("=== Add New Book ===");
            Console.Write("Title: ");
            var title = Console.ReadLine() ?? "";
            Console.Write("Author: ");
            var author = Console.ReadLine() ?? "";
            Console.Write("ISBN (13 digits): ");
            var isbn = Console.ReadLine() ?? "";
            try
            {
                service.AddBook(new BookDTO { Title = title, Author = author, ISBN = isbn });
                Console.WriteLine("\nBook added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
            PauseAndClear();
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("=== Update Book ===");
            Console.Write("Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int updateId))
            {
                var book = service.GetBookById(updateId);
                if (book == null)
                {
                    Console.WriteLine("❌ Book not found.");
                    PauseAndClear();
                    break;
                }

                Console.Write($"New Title ({book.Title}): ");
                var newTitle = Console.ReadLine();
                Console.Write($"New Author ({book.Author}): ");
                var newAuthor = Console.ReadLine();
                Console.Write($"New ISBN ({book.ISBN}): ");
                var newIsbn = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(newTitle)) book.Title = newTitle;
                if (!string.IsNullOrWhiteSpace(newAuthor)) book.Author = newAuthor;
                if (!string.IsNullOrWhiteSpace(newIsbn)) book.ISBN = newIsbn;

                try
                {
                    service.UpdateBook(book);
                    Console.WriteLine("\nBook updated successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            PauseAndClear();
            break;

        case "3":
            Console.Clear();
            Console.WriteLine("=== Delete Book ===");
            Console.Write("Book ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                service.DeleteBook(deleteId);
                Console.WriteLine("\nBook deleted successfully!");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            PauseAndClear();
            break;

        case "4":
            Console.Clear();
            Console.WriteLine("=== All Books ===");
            var books = service.GetAllBooks().ToList();

            if (!books.Any())
                Console.WriteLine("No books found.");
            else
                foreach (var b in books)
                    Console.WriteLine($"{b.Id}: {b.Title} by {b.Author} (ISBN: {b.ISBN})");

            PauseAndClear();
            break;

        case "5":
            Console.Clear();
            Console.WriteLine("=== View Book Details ===");
            Console.Write("Book ID: ");
            if (int.TryParse(Console.ReadLine(), out int viewId))
            {
                var book = service.GetBookById(viewId);
                if (book != null)
                {
                    Console.WriteLine($"\nID: {book.Id}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"ISBN: {book.ISBN}");
                }
                else
                    Console.WriteLine("Book not found.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            PauseAndClear();
            break;

        case "6":
            Console.Clear();
            Console.WriteLine("Exiting... Goodbye!");
            return;

        default:
            Console.WriteLine("Invalid choice. Please try again.");
            PauseAndClear();
            break;
    }
}

static void PauseAndClear()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
