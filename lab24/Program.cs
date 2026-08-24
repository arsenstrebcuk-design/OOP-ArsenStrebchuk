using lab24;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Створюємо контекст стратегії та видавця подій
NumericProcessor processor = new NumericProcessor(new SquareOperationStrategy());
ResultPublisher publisher = new ResultPublisher();

// Створюємо спостерігачів і підписуємо їх на подію ResultCalculated
ConsoleLoggerObserver consoleLogger = new ConsoleLoggerObserver();
HistoryLoggerObserver historyLogger = new HistoryLoggerObserver();
ThresholdNotifierObserver thresholdNotifier = new ThresholdNotifierObserver(100);

publisher.ResultCalculated += consoleLogger.OnResultCalculated;
publisher.ResultCalculated += historyLogger.OnResultCalculated;
publisher.ResultCalculated += thresholdNotifier.OnResultCalculated;

Console.WriteLine("=== Стратегія: Квадрат ===");
foreach (double x in new double[] { 5, 11, 3 })
{
    double r = processor.Process(x);
    publisher.PublishResult(r, $"Квадрат({x})");
}

Console.WriteLine("\n=== Стратегія: Куб (зміна під час виконання) ===");
processor.SetStrategy(new CubeOperationStrategy());
foreach (double x in new double[] { 2, 5 })
{
    double r = processor.Process(x);
    publisher.PublishResult(r, $"Куб({x})");
}

Console.WriteLine("\n=== Стратегія: Квадратний корінь ===");
processor.SetStrategy(new SquareRootOperationStrategy());
foreach (double x in new double[] { 16, 144 })
{
    double r = processor.Process(x);
    publisher.PublishResult(r, $"Корінь({x})");
}

Console.WriteLine();
historyLogger.PrintHistory();

Console.WriteLine();
SimpleTests.Run();
