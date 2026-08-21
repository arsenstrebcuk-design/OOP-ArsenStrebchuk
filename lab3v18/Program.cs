using lab3v18;

// Коректне відображення кирилиці в консолі
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Страва — колекція елементів їжі, що зберігаються як базовий тип FoodItem
List<FoodItem> dish = new List<FoodItem>
{
    new Fruit("Яблуко", 150, 52, true),
    new Fruit("Лимон", 80, 29, false),
    new Meat("Куряче філе", 200, 165, 31),
    new Meat("Яловичина", 250, 250, 26)
};

// Поліморфізм: для кожного обʼєкта викликається власна реалізація GetInfo()
Console.WriteLine("=== Склад страви ===");
foreach (FoodItem item in dish)
    Console.WriteLine(item.GetInfo());

// Загальна калорійність страви
double total = 0;
foreach (FoodItem item in dish)
    total += item.TotalCalories();
Console.WriteLine($"\nЗагальна калорійність страви: {total:F0} ккал");

// Порівняння за категоріями: сума калорій у кожній категорії
Console.WriteLine("\n=== Калорійність за категоріями ===");
var byCategory = dish
    .GroupBy(item => item.Category())
    .Select(g => new { Category = g.Key, Calories = g.Sum(i => i.TotalCalories()) });

foreach (var group in byCategory)
    Console.WriteLine($"{group.Category}: {group.Calories:F0} ккал");

// Демонстрація роботи деструктора
Console.WriteLine("\n=== Демонстрація деструктора ===");
dish.Clear();
GC.Collect();
GC.WaitForPendingFinalizers();

Console.WriteLine("\nКінець програми.");
