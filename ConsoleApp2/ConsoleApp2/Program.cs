// Клас для представлення замовлення
class Order
{
    public int OrderNumber { get; set; }
    public string DishName { get; set; }
    public int Quantity { get; set; }

    public Order(int orderNumber, string dishName, int quantity)
    {
        if (string.IsNullOrWhiteSpace(dishName))
            throw new ArgumentException("Назва страви не може бути порожньою.");
        if (quantity <= 0)
            throw new ArgumentException("Кількість повинна бути більше 0.");

        OrderNumber = orderNumber;
        DishName = dishName;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Замовлення №{OrderNumber}: {DishName}, Кількість: {Quantity}";
    }
}

// Клас для керування чергою замовлень
class OrderQueue
{
    private Queue<Order> orders = new Queue<Order>();

    // Додавання нового замовлення до черги
    public void AddOrder(Order order)
    {
        orders.Enqueue(order);
        Console.WriteLine($"Замовлення №{order.OrderNumber} додано до черги.");
    }

    // Видалення найстаршого замовлення з черги
    public void RemoveOrder()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("Черга порожня. Немає замовлень для видалення.");
            return;
        }

        Order removedOrder = orders.Dequeue();
        Console.WriteLine($"Замовлення №{removedOrder.OrderNumber} видалено з черги.");
    }

    // Отримання найстаршого замовлення з черги без його видалення
    public void PeekOrder()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("Черга порожня. Немає замовлень для перегляду.");
            return;
        }

        Order oldestOrder = orders.Peek();
        Console.WriteLine($"Найстаріше замовлення у черзі: {oldestOrder}");
    }

    // Перевірка чи черга порожня
    public bool IsEmpty()
    {
        return orders.Count == 0;
    }
}

// Головний клас програми
class Program
{
    static void Main()
    {
        var orderQueue = new OrderQueue();

        while (true)
        {
            Console.WriteLine("\nВиберіть операцію:");
            Console.WriteLine("1 - Додати нове замовлення");
            Console.WriteLine("2 - Видалити найстарше замовлення");
            Console.WriteLine("3 - Переглянути найстарше замовлення");
            Console.WriteLine("4 - Вийти");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть номер замовлення: ");
                        int orderNumber = int.Parse(Console.ReadLine());
                        Console.Write("Введіть назву страви: ");
                        string dishName = Console.ReadLine();
                        Console.Write("Введіть кількість: ");
                        int quantity = int.Parse(Console.ReadLine());

                        var order = new Order(orderNumber, dishName, quantity);
                        orderQueue.AddOrder(order);
                        break;

                    case "2":
                        orderQueue.RemoveOrder();
                        break;

                    case "3":
                        orderQueue.PeekOrder();
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