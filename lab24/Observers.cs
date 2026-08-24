namespace lab24;

// Спостерігачі (Observers), підписуються на подію ResultCalculated.

// Виводить результат і назву операції в консоль
public class ConsoleLoggerObserver
{
    public void OnResultCalculated(double result, string operationName)
        => Console.WriteLine($"  [Console] Операція '{operationName}' => результат {result:N4}");
}

// Зберігає історію результатів у List<string>
public class HistoryLoggerObserver
{
    private readonly List<string> _history = new List<string>();

    public IReadOnlyList<string> History => _history;

    public void OnResultCalculated(double result, string operationName)
        => _history.Add($"{operationName}: {result:N4}");

    public void PrintHistory()
    {
        Console.WriteLine("  [History] Історія результатів:");
        foreach (string entry in _history)
            Console.WriteLine($"    - {entry}");
    }
}

// Сповіщає, якщо результат перевищив порогове значення
public class ThresholdNotifierObserver
{
    private readonly double _threshold;

    public ThresholdNotifierObserver(double threshold)
    {
        _threshold = threshold;
    }

    public void OnResultCalculated(double result, string operationName)
    {
        if (result > _threshold)
            Console.WriteLine($"  [Threshold] УВАГА: результат {result:N4} перевищив поріг {_threshold:N2}!");
    }
}
