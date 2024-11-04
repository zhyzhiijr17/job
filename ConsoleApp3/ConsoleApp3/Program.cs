// Клас для представлення книги
class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal Price { get; set; }

    public Book(string title, string author, decimal price)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Назва книги не може бути порожньою.");
        if (string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Автор книги не може бути порожнім.");
        if (price < 0)
            throw new ArgumentException("Ціна книги не може бути від'ємною.");

        Title = title;
        Author = author;
        Price = price;
    }

    public override string ToString()
    {
        return $"Назва: {Title}, Автор: {Author}, Ціна: {Price} грн";
    }
}

// Клас для керування каталогом книг
class BookStore
{
    private Dictionary<int, Book> books = new Dictionary<int, Book>();

    // Додавання нової книги до каталогу
    public void AddBook(int id, Book book)
    {
        if (books.ContainsKey(id))
        {
            Console.WriteLine($"Книга з ідентифікатором {id} вже існує.");
            return;
        }
        books[id] = book;
        Console.WriteLine($"Книга '{book.Title}' додана до каталогу з ідентифікатором {id}.");
    }

    // Видалення книги за ідентифікатором
    public void RemoveBook(int id)
    {
        if (books.Remove(id))
        {
            Console.WriteLine($"Книга з ідентифікатором {id} видалена з каталогу.");
        }
        else
        {
            Console.WriteLine($"Книга з ідентифікатором {id} не знайдена.");
        }
    }

    // Отримання інформації про книгу за ідентифікатором
    public void GetBookInfo(int id)
    {
        if (books.TryGetValue(id, out Book book))
        {
            Console.WriteLine($"Інформація про книгу з ідентифікатором {id}: {book}");
        }
        else
        {
            Console.WriteLine($"Книга з ідентифікатором {id} не знайдена.");
        }
    }
}

// Головний клас програми
class Program
{
    static void Main()
    {
        var bookstore = new BookStore();

        while (true)
        {
            Console.WriteLine("\nВиберіть операцію:");
            Console.WriteLine("1 - Додати нову книгу");
            Console.WriteLine("2 - Видалити книгу за ідентифікатором");
            Console.WriteLine("3 - Отримати інформацію про книгу за ідентифікатором");
            Console.WriteLine("4 - Вийти");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть унікальний ідентифікатор книги: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введіть назву книги: ");
                        string title = Console.ReadLine();
                        Console.Write("Введіть автора книги: ");
                        string author = Console.ReadLine();
                        Console.Write("Введіть ціну книги: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        var book = new Book(title, author, price);
                        bookstore.AddBook(id, book);
                        break;

                    case "2":
                        Console.Write("Введіть ідентифікатор книги для видалення: ");
                        int removeId = int.Parse(Console.ReadLine());
                        bookstore.RemoveBook(removeId);
                        break;

                    case "3":
                        Console.Write("Введіть ідентифікатор книги для перегляду: ");
                        int viewId = int.Parse(Console.ReadLine());
                        bookstore.GetBookInfo(viewId);
                        break;

                    case "4":
                        Console.WriteLine("Програма завершена.");
                        return;

                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: введіть коректні числові значення.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}