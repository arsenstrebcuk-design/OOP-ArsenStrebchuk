using lab6v8;

// Коректне відображення кирилиці в консолі
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("=== Власний делегат Operation ===");

// Анонімний метод, присвоєний власному делегату Operation
Operation add = delegate (int a, int b) { return a + b; };

// Лямбда-вираз, присвоєний тому ж типу делегата
Operation mul = (a, b) => a * b;

Console.WriteLine($"add(3, 5) = {add(3, 5)}");
Console.WriteLine($"mul(3, 5) = {mul(3, 5)}");


Console.WriteLine("\n=== Вбудовані делегати (Func, Action, Predicate) ===");

NumberService service = new NumberService();

Console.WriteLine($"IsDivisible(20, 5) = {service.IsDivisible(20, 5)}");
Console.WriteLine($"IsPrime(13)        = {service.IsPrime(13)}");
Console.WriteLine($"IsPrime(15)        = {service.IsPrime(15)}");


Console.WriteLine("\n=== Predicate<int>: видалення непотрібних елементів ===");

List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
Console.Write("Початковий список: ");
service.PrintList(numbers);                 // Action<List<int>>

service.RemoveUnneeded(numbers, service.IsOdd);   // Predicate<int>
Console.Write("Після видалення непарних: ");
service.PrintList(numbers);


Console.WriteLine("\n=== LINQ-обробка колекції ===");

List<int> nums = new() { 5, 2, 8, 1, 9, 3, 7, 4, 6 };

Console.Write("Where (парні):     ");
service.PrintList(LinqProcessor.Evens(nums));

Console.Write("Select (квадрати): ");
service.PrintList(LinqProcessor.Squared(nums));

Console.Write("OrderBy:           ");
service.PrintList(LinqProcessor.Sorted(nums));

Console.WriteLine($"Aggregate (сума):  {LinqProcessor.Sum(nums)}");


Console.WriteLine("\n=== Func<int, int, bool> для перевірки чисел ===");

foreach (int n in new[] { 7, 12, 17, 20 })
    Console.WriteLine($"{n}: просте? {service.IsPrime(n)}, ділиться на 5? {service.IsDivisible(n, 5)}");


Console.WriteLine("\n=== БОНУС: комбіновані делегати (multicast) ===");

// Кілька Action<string> об'єднані в один делегат
Action<string> logger = s => Console.WriteLine($"[LOG]  {s}");
logger += s => Console.WriteLine($"[ECHO] {s.ToUpper()}");
logger += s => Console.WriteLine($"[LEN]  довжина = {s.Length}");

// Один виклик запускає всі три методи по черзі
logger("Комбінований делегат");
