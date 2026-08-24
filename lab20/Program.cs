using lab20;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Dependency Injection: збираємо OrderService з конкретних реалізацій.
// Замінивши реалізацію (напр. на справжню БД), клас OrderService чіпати не треба.
IOrderValidator validator = new OrderValidator();
IOrderRepository repository = new InMemoryOrderRepository();
IEmailService emailService = new ConsoleEmailService();

OrderService orderService = new OrderService(validator, repository, emailService);

Console.WriteLine("=== Валідне замовлення ===");
Order validOrder = new Order(1, "Іван Петренко", 1500.00m);
orderService.ProcessOrder(validOrder);

Console.WriteLine("\n=== Невалідне замовлення (сума <= 0) ===");
Order invalidOrder = new Order(2, "Олена Коваль", 0m);
orderService.ProcessOrder(invalidOrder);

Console.WriteLine("\n=== Перевірка GetById через репозиторій ===");
Order? found = repository.GetById(1);
Console.WriteLine(found is not null
    ? $"Знайдено замовлення #{found.Id} клієнта {found.CustomerName}, статус {found.Status}."
    : "Замовлення #1 не знайдено.");

Order? notFound = repository.GetById(2);
Console.WriteLine(notFound is not null
    ? $"Знайдено замовлення #{notFound.Id}."
    : "Замовлення #2 не знайдено (не збережено, бо було невалідне).");
