namespace lab24;

// Контекст патерну Strategy: делегує обробку поточній стратегії,
// яку можна змінювати під час виконання.
public class NumericProcessor
{
    private INumericOperationStrategy _strategy;

    public NumericProcessor(INumericOperationStrategy strategy)
    {
        _strategy = strategy;
    }

    // Зміна стратегії під час виконання
    public void SetStrategy(INumericOperationStrategy strategy)
    {
        _strategy = strategy;
    }

    // Делегує обробку поточній стратегії
    public double Process(double input) => _strategy.Execute(input);
}
