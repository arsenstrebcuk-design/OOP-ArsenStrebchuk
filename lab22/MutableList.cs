namespace lab22;

// Повноцінний змінюваний список: реалізує IMutableList і чесно виконує Add().
public class MutableList : IMutableList
{
    private readonly List<int> _items = new List<int>();

    public MutableList() { }
    public MutableList(IEnumerable<int> initial) => _items.AddRange(initial);

    public void Add(int item) => _items.Add(item);

    public int Count => _items.Count;
    public int this[int index] => _items[index];
    public IEnumerable<int> Items => _items;
}
