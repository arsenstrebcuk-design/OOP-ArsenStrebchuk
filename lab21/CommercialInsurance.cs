namespace lab21;

// НОВА, 4-та стратегія (демонстрація OCP).
// Комерційне використання авто: найвищий тариф + фіксована комерційна надбавка.
// Додається БЕЗ будь-яких змін у класі InsuranceService.
public class CommercialInsurance : IInsuranceStrategy
{
    public decimal CalculatePremium(int driverAge, int drivingExperience, decimal carValue)
    {
        decimal rate = 0.10m;      // 10% вартості авто
        decimal risk = 1.0m;

        if (driverAge < 25) risk += 0.7m;
        if (drivingExperience < 5) risk += 0.6m;

        return carValue * rate * risk + 5000m;     // комерційна надбавка
    }
}
