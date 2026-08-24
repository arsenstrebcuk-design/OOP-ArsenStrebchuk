namespace lab6v8;

// Обробка колекцій за допомогою LINQ-виразів та лямбд.
public static class LinqProcessor
{
    // Where — фільтрація парних (лямбда-вираз)
    public static List<int> Evens(IEnumerable<int> source)
        => source.Where(x => x % 2 == 0).ToList();

    // Select — перетворення (піднесення до квадрата)
    public static List<int> Squared(IEnumerable<int> source)
        => source.Select(x => x * x).ToList();

    // OrderBy — сортування за зростанням
    public static List<int> Sorted(IEnumerable<int> source)
        => source.OrderBy(x => x).ToList();

    // Aggregate — згортка (сума всіх елементів)
    public static int Sum(IEnumerable<int> source)
        => source.Aggregate(0, (acc, x) => acc + x);
}
