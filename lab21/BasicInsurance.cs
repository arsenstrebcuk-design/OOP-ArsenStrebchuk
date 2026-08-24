namespace lab21;

// Базовий поліс (обов'язкове страхування).
// Найнижчий тариф, м'які коефіцієнти ризику.
public class BasicInsurance : IInsuranceStrategy
{
    public decimal CalculatePremium(int driverAge, int drivingExperience, decimal carValue)
    {
        decimal rate = 0.03m;      // 3% вартості авто
        decimal risk = 1.0m;

        if (driverAge < 25) risk += 0.5m;          // молодий водій
        if (drivingExperience < 3) risk += 0.4m;   // малий стаж

        return carValue * rate * risk;
    }
}
