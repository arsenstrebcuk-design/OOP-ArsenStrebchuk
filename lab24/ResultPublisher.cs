namespace lab24;

// Патерн Observer (Subject): сповіщає підписників через подію C#.
public class ResultPublisher
{
    // Подія: (результат, назва операції)
    public event Action<double, string>? ResultCalculated;

    // Викликає подію — усі підписані спостерігачі отримають сповіщення
    public void PublishResult(double result, string operationName)
    {
        ResultCalculated?.Invoke(result, operationName);
    }
}
