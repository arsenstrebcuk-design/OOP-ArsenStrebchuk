namespace lab22;

// Список лише для читання через КОМПОЗИЦІЮ: обгортає будь-яке джерело IReadableList.
// Реалізує ЛИШЕ IReadableList, тож методу Add тут НЕ існує взагалі —
// а отже й ламати нічого. Порушення LSP стало неможливим на рівні типів.
public class ReadOnlyListView : IReadableList
{
    private readonly IReadableList _source;

    public ReadOnlyListView(IReadableList source) => _source = source;

    public int Count => _source.Count;
    public int this[int index] => _source[index];
    public IEnumerable<int> Items => _source.Items;
}
