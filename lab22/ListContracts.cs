namespace lab22;

// РЕФАКТОРИНГ. Розділяємо контракти: читання окремо, зміна окремо.

// Контракт лише для читання
public interface IReadableList
{
    int Count { get; }
    int this[int index] { get; }
    IEnumerable<int> Items { get; }
}

// Контракт для змінюваного списку (розширює читабельний)
public interface IMutableList : IReadableList
{
    void Add(int item);
}
