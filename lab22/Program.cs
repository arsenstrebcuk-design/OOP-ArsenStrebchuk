using lab22;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("======== ПОЧАТКОВА ІЄРАРХІЯ (порушує LSP) ========\n");

CustomList mutable = new CustomList();
Console.WriteLine("Заповнюємо CustomList 1..3 клієнтським методом FillList:");
FillList(mutable, 3);                 // працює
PrintCustom(mutable);

ReadOnlyList readOnly = new ReadOnlyList(new[] { 10, 20, 30 });
Console.WriteLine("\nПередаємо ReadOnlyList у той самий метод FillList (це ж теж CustomList):");
try
{
    FillList(readOnly, 3);            // мало б працювати, бо ReadOnlyList : CustomList
}
catch (NotSupportedException ex)
{
    Console.WriteLine($"  !!! ПОРУШЕННЯ LSP: {ex.Message}");
    Console.WriteLine("  Підтип не підставляється замість базового типу без поломки коду.");
}


Console.WriteLine("\n\n======== РЕФАКТОРИНГ (дотримується LSP) ========\n");

MutableList data = new MutableList();
FillMutable(data, 3);                 // приймає IMutableList — працює
Console.WriteLine("MutableList після заповнення 1..3:");
Print(data);

ReadOnlyListView view = new ReadOnlyListView(data);
Console.WriteLine("\nReadOnlyListView (композиція над MutableList) — лише читання:");
Print(view);                          // приймає IReadableList — теж працює

Console.WriteLine("\nReadOnlyListView не має методу Add і несумісний із FillMutable(IMutableList),");
Console.WriteLine("тож порушення просто НЕ може статися — це гарантує компілятор ще до запуску.");


// ===== Клієнтські методи =====

// Початкова версія: написаний під базовий тип CustomList, очікує робочий Add()
static void FillList(CustomList list, int count)
{
    for (int i = 1; i <= count; i++)
        list.Add(i);
}

static void PrintCustom(CustomList list)
    => Console.WriteLine("  [" + string.Join(", ", list.Items) + "]");

// Рефакторинг: потребує змінюваності -> IMutableList (read-only список сюди не передати)
static void FillMutable(IMutableList list, int count)
{
    for (int i = 1; i <= count; i++)
        list.Add(i);
}

// Рефакторинг: потребує лише читання -> IReadableList (працює з будь-яким читабельним списком)
static void Print(IReadableList list)
    => Console.WriteLine("  [" + string.Join(", ", list.Items) + "]  (Count=" + list.Count + ")");
