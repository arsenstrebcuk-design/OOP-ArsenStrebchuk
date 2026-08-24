namespace lab21;

// Повне покриття (КАСКО): найвищий тариф і найсуворіші коефіцієнти ризику.
public class FullCoverage : IInsuranceStrategy
{
    public decimal CalculatePremium(int driverAge, int drivingExperience, decimal carValue)
    {
        decimal rate = 0.08m;      // 8% вартості авто
        decimal risk = 1.0m;

        if (driverAge < 25) risk += 0.7m;
        if (driverAge > 65) risk += 0.4m;
        if (drivingExperience < 5) risk += 0.6m;

        return carValue * rate * risk + 2500m;     // фіксована доплата за повне покриття
    }
}
