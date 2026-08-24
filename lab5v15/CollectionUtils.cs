namespace lab5v15;

public static class CollectionUtils
{
    // Узагальнений метод: повертає N елементів з найбільшим значенням за селектором
    public static List<T> TopN<T>(IEnumerable<T> source, int n, Func<T, double> selector)
    {
        return source
            .OrderByDescending(selector)
            .Take(n)
            .ToList();
    }
}
