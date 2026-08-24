namespace lab21;

// Розширений поліс: більше покриття, вищий тариф і строгіші коефіцієнти.
public class ExtendedInsurance : IInsuranceStrategy
{
    public decimal CalculatePremium(int driverAge, int drivingExperience, decimal carValue)
    {
        decimal rate = 0.05m;      // 5% вартості авто
        decimal risk = 1.0m;

        if (driverAge < 25) risk += 0.6m;
        if (driverAge > 65) risk += 0.3m;          // водій похилого віку
        if (drivingExperience < 3) risk += 0.5m;

        return carValue * rate * risk + 1000m;     // фіксована доплата за розширене покриття
    }
}
