// Клас для представлення документа
class Document
{
    public string Title { get; set; }
    public string Content { get; set; }

    public Document(string title, string content)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Назва документа не може бути порожньою.");
        if (string.IsNullOrWhiteSpace(content))
            throw new ArgumentException("Зміст документа не може бути порожнім.");

        Title = title;
        Content = content;
    }

    public override string ToString()
    {
        return $"Назва: {Title}, Зміст: {Content}";
    }
}

// Клас для керування стеком документів
class DocumentStack
{
    private Stack<Document> documents = new Stack<Document>();

    // Додавання нового документа до стеку
    public void AddDocument(Document doc)
    {
        documents.Push(doc);
        Console.WriteLine($"Документ '{doc.Title}' додано до стеку.");
    }

    // Видалення верхнього документа зі стеку
    public void RemoveDocument()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("Стек порожній. Немає документів для видалення.");
            return;
        }

        Document removedDoc = documents.Pop();
        Console.WriteLine($"Документ '{removedDoc.Title}' видалено зі стеку.");
    }

    // Отримання верхнього документа зі стеку без його видалення
    public void PeekDocument()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("Стек порожній. Немає документів для перегляду.");
            return;
        }

        Document topDoc = documents.Peek();
        Console.WriteLine($"Верхній документ у стеці: {topDoc}");
    }

    // Перевірка чи стек порожній
    public bool IsEmpty()
    {
        return documents.Count == 0;
    }
}

// Головний клас програми
class Program
{
    static void Main()
    {
        var documentStack = new DocumentStack();

        while (true)
        {
            Console.WriteLine("\nВиберіть операцію:");
            Console.WriteLine("1 - Додати новий документ");
            Console.WriteLine("2 - Видалити верхній документ");
            Console.WriteLine("3 - Переглянути верхній документ");
            Console.WriteLine("4 - Вийти");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть назву документа: ");
                        string title = Console.ReadLine();
                        Console.Write("Введіть зміст документа: ");
                        string content = Console.ReadLine();

                        var doc = new Document(title, content);
                        documentStack.AddDocument(doc);
                        break;

                    case "2":
                        documentStack.RemoveDocument();
                        break;

                    case "3":
                        documentStack.PeekDocument();
                        break;

                    case "4":
                        Console.WriteLine("Програма завершена.");
                        return;

                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }
        }
    }
}