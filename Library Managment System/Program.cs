class  Book
{
    private string title;
    private string author;
    private string isbn;
    private bool is_available;

    public Book(string title, string author, string isbn)
    {
        this.title = title;
        this.author = author;
        this.isbn = isbn;
        is_available = true;
    }
    
    public string Title { get => title; set => title = value; }
    public string Author { get => author; set => author = value; }
    public string Isbn { get => isbn; set => isbn = value; }
    public bool Is_available { get => is_available; set => is_available = value; }
}

class Library
{
    private List<Book> books = new List<Book>();
    
    public Book AddBook(Book book)
    {
         if (books.Any(b => b.Isbn == book.Isbn))
         {
             Console.WriteLine("Book already exists.");
             return null;
         }
         
         this.books.Add(book);
         return book;
    }
    
    public void SearchBook(string isbn)
    {  
        foreach (Book book in books)
        {
            if (book.Isbn == isbn && book.Is_available)
            {
                Console.WriteLine($"Found: {book.Title} by {book.Author}");
                book.Is_available = false;
                return;
            }
        }
        Console.WriteLine("Book not found or not available.");
    }

    public void BorrowBook()
    {
        Console.WriteLine("Enter the ISBN of the book to borrow:");
        string isbn = Console.ReadLine();
        SearchBook(isbn);
    }
    
    public void ReturnBook()
    {
        Console.WriteLine("Enter the ISBN of the book to return:");
        string isbn = Console.ReadLine();
        foreach (Book book in books)
        {
            if (book.Isbn == isbn)
            {
                book.Is_available = true;
                Console.WriteLine($"Returned: {book.Title} by {book.Author}");
                return;
            }
        }
        Console.WriteLine("Book not found or not borrowed.");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();

        library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780141951711"));
        library.AddBook(new Book("1984", "George Orwell", "9780415249355"));
        library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));

        while (true)
        {
            Console.WriteLine("\nLibrary Management System:");
            Console.WriteLine("1. Add a book");
            Console.WriteLine("2. Search for a book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title of the book:");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter the author of the book:");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter the ISBN of the book:");
                        string isbn = Console.ReadLine();

                        library.AddBook(new Book(title, author, isbn));
                        break;
                    case 2:
                        Console.WriteLine("Enter the ISBN of the book to search:");
                        isbn = Console.ReadLine();
                        library.SearchBook(isbn);
                        break;
                    case 3:
                        library.BorrowBook();
                        break;
                    case 4:
                        library.ReturnBook();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}