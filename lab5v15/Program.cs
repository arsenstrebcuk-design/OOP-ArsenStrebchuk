using lab5v15;

// Коректне відображення кирилиці в консолі
Console.OutputEncoding = System.Text.Encoding.UTF8;

PostOffice office = new PostOffice("Відділення №1");

// Створення даних
office.Register(new Shipment("A001", "Київ", new DateTime(2026, 1, 5), new DateTime(2026, 1, 7), ShipmentStatus.Delivered));
office.Register(new Shipment("A002", "Львів", new DateTime(2026, 1, 5), new DateTime(2026, 1, 9), ShipmentStatus.Delivered));
office.Register(new Shipment("A003", "Київ", new DateTime(2026, 1, 6), new DateTime(2026, 1, 8), ShipmentStatus.Delivered));
office.Register(new Shipment("A004", "Одеса", new DateTime(2026, 1, 6), new DateTime(2026, 1, 6), ShipmentStatus.Lost));
office.Register(new Shipment("A005", "Київ", new DateTime(2026, 1, 7), new DateTime(2026, 1, 11), ShipmentStatus.Damaged));
office.Register(new Shipment("A006", "Львів", new DateTime(2026, 1, 8), new DateTime(2026, 1, 10), ShipmentStatus.Delivered));

Console.WriteLine($"Відділення: {office.Name}");
Console.WriteLine($"Усього відправлень: {office.Shipments.Count}\n");

// Обчислення по колекції
Console.WriteLine($"Середній термін доставки: {office.AverageDeliveryDays():F1} дн.");
Console.WriteLine($"Втрачено/пошкоджено: {office.LostOrDamagedFraction():F1}%\n");

Console.WriteLine("Топ-напрямки:");
foreach (string destination in office.TopDestinations(3))
    Console.WriteLine($"  {destination}");

// Обробка винятку №1: некоректні дати відправлення
Console.WriteLine("\n=== Обробка винятків ===");
try
{
    office.Register(new Shipment("A007", "Харків",
        new DateTime(2026, 1, 10), new DateTime(2026, 1, 8), ShipmentStatus.Delivered));
}
catch (InvalidShipmentDatesException ex)
{
    Console.WriteLine($"Помилка дат: {ex.Message}");
}

// Обробка винятку №2: пошук неіснуючого відправлення
try
{
    Shipment found = office.FindByTracking("A999");
}
catch (NotFoundException ex)
{
    Console.WriteLine($"Помилка пошуку: {ex.Message}");
}
