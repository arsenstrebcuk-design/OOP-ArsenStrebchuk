using lab2v18;

Rectangle r1 = new Rectangle(4, 3);
Console.WriteLine(r1);
Console.WriteLine($"Площа: {r1.Area}, Периметр: {r1.Perimeter}");

r1.Width = 6;
Console.WriteLine($"Після зміни ширини: {r1}");

Console.WriteLine($"Через індексатор: ширина = {r1[0]}, висота = {r1[1]}");
r1[1] = 5;
Console.WriteLine($"Після r1[1] = 5: {r1}");

Rectangle r2 = r1 * 2;
Console.WriteLine($"r1 * 2 = {r2}");

Rectangle r3 = 0.5 * r2;
Console.WriteLine($"0.5 * r2 = {r3}");

Console.WriteLine($"r1 == r3: {r1 == r3}");
Console.WriteLine($"r1 != r2: {r1 != r2}");

try
{
    r1.Height = -10;
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Помилка валідації: {ex.Message}");
}
