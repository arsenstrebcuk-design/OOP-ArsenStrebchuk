namespace lab21;

// Контекстний клас. Залежить ЛИШЕ від інтерфейсу IInsuranceStrategy,
// а не від конкретних реалізацій. Стратегія передається в конструктор.
// Саме тому додавання нових стратегій НЕ вимагає зміни цього класу (OCP).
public class InsuranceService
{
    private readonly IInsuranceStrategy _strategy;

    public InsuranceService(IInsuranceStrategy strategy)
    {
        _strategy = strategy;
    }

    public decimal CalculatePremium(int driverAge, int drivingExperience, decimal carValue)
        => _strategy.CalculatePremium(driverAge, drivingExperience, carValue);
}
