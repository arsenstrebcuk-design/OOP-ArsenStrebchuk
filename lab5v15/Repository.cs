namespace lab5v15;

// Узагальнене сховище: працює з елементами будь-якого типу T
public class Repository<T> : IRepository<T>
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item) => _items.Add(item);

    public bool Remove(T item) => _items.Remove(item);

    // Пошук першого відповідного елемента; кидає NotFoundException, якщо нема
    public T Find(Func<T, bool> predicate)
    {
        foreach (T item in _items)
            if (predicate(item))
                return item;
        throw new NotFoundException("Елемент не знайдено у сховищі.");
    }

    public IReadOnlyList<T> All() => _items;

    public List<T> Where(Func<T, bool> predicate) => _items.Where(predicate).ToList();
}
