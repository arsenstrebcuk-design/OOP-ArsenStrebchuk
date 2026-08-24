namespace lab24;

// Патерн Strategy: контракт числової операції.
public interface INumericOperationStrategy
{
    double Execute(double value);
}
