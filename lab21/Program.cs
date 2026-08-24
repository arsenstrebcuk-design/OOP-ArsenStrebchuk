using lab21;

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Профіль водія для розрахунку (демонстраційні дані)
int driverAge = 23;
int drivingExperience = 2;
decimal carValue = 500_000m;   // грн

Console.WriteLine($"Водій: вік {driverAge}, стаж {drivingExperience} р., авто {carValue:N0} грн\n");

// Розрахунок усіх базових типів полісу через фабрику
string[] policyTypes = { "basic", "extended", "full" };

foreach (string type in policyTypes)
{
    // Фабрика створює стратегію, сервіс лише рахує через інтерфейс
    IInsuranceStrategy strategy = InsuranceStrategyFactory.CreateStrategy(type);
    InsuranceService service = new InsuranceService(strategy);

    decimal premium = service.CalculatePremium(driverAge, drivingExperience, carValue);
    Console.WriteLine($"{type,-10} => премія: {premium:N2} грн");
}

Console.WriteLine("\n=== Демонстрація OCP: додаємо 4-ту стратегію 'commercial' ===");
Console.WriteLine("Клас InsuranceService НЕ змінювався — лише додано нову стратегію та запис у фабрику.\n");

IInsuranceStrategy commercial = InsuranceStrategyFactory.CreateStrategy("commercial");
InsuranceService commercialService = new InsuranceService(commercial);

decimal commercialPremium = commercialService.CalculatePremium(driverAge, drivingExperience, carValue);
Console.WriteLine($"commercial => премія: {commercialPremium:N2} грн");

Console.WriteLine("\n=== Порівняння для досвідченого водія (вік 40, стаж 15) ===");
int age2 = 40, exp2 = 15;
foreach (string type in new[] { "basic", "extended", "full", "commercial" })
{
    IInsuranceStrategy s = InsuranceStrategyFactory.CreateStrategy(type);
    InsuranceService svc = new InsuranceService(s);
    Console.WriteLine($"{type,-10} => премія: {svc.CalculatePremium(age2, exp2, carValue):N2} грн");
}
