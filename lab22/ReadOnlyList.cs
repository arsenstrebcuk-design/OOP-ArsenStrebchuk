namespace lab22;

// Похідний клас: список лише для читання.
// ПОРУШУЄ LSP: успадковує Add() від CustomList, але не може виконати його контракт —
// замість додавання кидає виняток. Отже ReadOnlyList НЕ є коректним підтипом CustomList:
// будь-який код, написаний під CustomList і розрахований на робочий Add(), зламається.
public class ReadOnlyList : CustomList
{
    public ReadOnlyList(IEnumerable<int> initial)
    {
        _items.AddRange(initial);
    }

    public override void Add(int item)
        => throw new NotSupportedException("ReadOnlyList не підтримує додавання елементів.");
}
