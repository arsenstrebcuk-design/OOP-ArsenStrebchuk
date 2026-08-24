namespace lab24;

// Легкі юніт-тести без зовнішнього фреймворку (щоб запускалися будь-де, зокрема у Fiddle).
// У "справжньому" проєкті ці ж перевірки оформлюються як [Fact]-методи xUnit.
public static class SimpleTests
{
    private static int _passed = 0;
    private static int _failed = 0;

    private static void Check(bool condition, string name)
    {
        if (condition) { _passed++; Console.WriteLine($"  [PASS] {name}"); }
        else           { _failed++; Console.WriteLine($"  [FAIL] {name}"); }
    }

    private static void CheckEqual(double expected, double actual, string name, double eps = 1e-9)
        => Check(Math.Abs(expected - actual) < eps, $"{name} (очікувано {expected}, отримано {actual})");

    public static void Run()
    {
        Console.WriteLine("======== ЮНІТ-ТЕСТИ ========\n");

        // Strategy
        CheckEqual(25, new SquareOperationStrategy().Execute(5), "Square(5) == 25");
        CheckEqual(27, new CubeOperationStrategy().Execute(3), "Cube(3) == 27");
        CheckEqual(4, new SquareRootOperationStrategy().Execute(16), "Sqrt(16) == 4");

        // NumericProcessor + SetStrategy
        NumericProcessor processor = new NumericProcessor(new SquareOperationStrategy());
        CheckEqual(49, processor.Process(7), "Processor Square(7) == 49");
        processor.SetStrategy(new CubeOperationStrategy());
        CheckEqual(8, processor.Process(2), "Після SetStrategy Cube(2) == 8");

        // SquareRoot від'ємного кидає виняток
        bool threw = false;
        try { new SquareRootOperationStrategy().Execute(-1); }
        catch (ArgumentException) { threw = true; }
        Check(threw, "Sqrt(-1) кидає ArgumentException");

        // Observer: подія доставляє дані підписнику
        ResultPublisher publisher = new ResultPublisher();
        double captured = 0; string capturedOp = "";
        publisher.ResultCalculated += (r, op) => { captured = r; capturedOp = op; };
        publisher.PublishResult(42, "Test");
        CheckEqual(42, captured, "Подія доставила результат спостерігачу");
        Check(capturedOp == "Test", "Подія доставила назву операції");

        // HistoryLogger накопичує записи
        HistoryLoggerObserver history = new HistoryLoggerObserver();
        ResultPublisher pub2 = new ResultPublisher();
        pub2.ResultCalculated += history.OnResultCalculated;
        pub2.PublishResult(1, "op1");
        pub2.PublishResult(2, "op2");
        Check(history.History.Count == 2, "HistoryLogger накопичив 2 записи");

        Console.WriteLine($"\nПідсумок: {_passed} пройдено, {_failed} провалено.");
    }
}
