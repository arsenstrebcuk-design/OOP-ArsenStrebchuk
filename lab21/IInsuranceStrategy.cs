namespace lab21;

// Контракт стратегії розрахунку страхового полісу.
// Параметри варіанту 8: вік водія, стаж водіння, вартість авто.
public interface IInsuranceStrategy
{
    decimal CalculatePremium(int driverAge, int drivingExperience, decimal carValue);
}
