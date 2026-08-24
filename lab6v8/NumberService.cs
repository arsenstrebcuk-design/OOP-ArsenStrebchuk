namespace lab6v8;

// Сервіс обробки чисел на основі вбудованих делегатів.
// Демонструє Func<>, Action<>, Predicate<> згідно з варіантом 8.
public class NumberService
{
    // Func<int, int, bool> — приймає два int, повертає bool
    // (перевірка: чи ділиться перше число на друге без остачі)
    public Func<int, int, bool> IsDivisible { get; } = (num, div) => div != 0 && num % div == 0;

    // Func<int, bool> — перевірка простого числа
    public Func<int, bool> IsPrime { get; } = n =>
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    };

    // Action<List<int>> — друк списку в консоль, значення не повертає
    public Action<List<int>> PrintList { get; } = list =>
        Console.WriteLine("[" + string.Join(", ", list) + "]");

    // Predicate<int> — булева перевірка для видалення елементів (непарні)
    public Predicate<int> IsOdd { get; } = n => n % 2 != 0;

    // Видалення непотрібних елементів через Predicate<int>
    public void RemoveUnneeded(List<int> numbers, Predicate<int> unwanted)
        => numbers.RemoveAll(unwanted);
}
