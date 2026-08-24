namespace lab24;

// Конкретні стратегії обробки числа.

public class SquareOperationStrategy : INumericOperationStrategy
{
    public double Execute(double value) => value * value;
}

public class CubeOperationStrategy : INumericOperationStrategy
{
    public double Execute(double value) => value * value * value;
}

public class SquareRootOperationStrategy : INumericOperationStrategy
{
    public double Execute(double value)
    {
        if (value < 0)
            throw new ArgumentException("Не можна взяти квадратний корінь від'ємного числа.");
        return Math.Sqrt(value);
    }
}
