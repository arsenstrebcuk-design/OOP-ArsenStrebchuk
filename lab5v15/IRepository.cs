namespace lab5v15;

// Узагальнений контракт сховища для будь-якого типу T
public interface IRepository<T>
{
    void Add(T item);
    bool Remove(T item);
    T Find(Func<T, bool> predicate);
    IReadOnlyList<T> All();
    List<T> Where(Func<T, bool> predicate);
}
