namespace lab22;

// ПОЧАТКОВА ІЄРАРХІЯ (порушує LSP).
// Базовий клас: список, у який можна додавати елементи.
// Контракт Add(item): після виклику список містить item, а Count зростає на 1.
public class CustomList
{
    protected readonly List<int> _items = new List<int>();

    public virtual void Add(int item) => _items.Add(item);

    public int Count => _items.Count;
    public int this[int index] => _items[index];
    public IEnumerable<int> Items => _items;
}
