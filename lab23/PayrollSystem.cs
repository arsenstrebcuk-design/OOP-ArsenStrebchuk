namespace lab23.Refactored;

// Головний (високорівневий) клас тепер залежить ЛИШЕ від абстракцій (інтерфейсів),
// а не від конкретних класів. Залежності вводяться через конструктор (DIP + DI).
public class PayrollSystem
{
    private readonly ISalaryCalculator _calculator;
    private readonly IReportExporter _exporter;
    private readonly IReportRepository _repository;

    public PayrollSystem(
        ISalaryCalculator calculator,
        IReportExporter exporter,
        IReportRepository repository)
    {
        _calculator = calculator;
        _exporter = exporter;
        _repository = repository;
    }

    public void ProcessPayroll(string employee, decimal baseSalary, int workedDays)
    {
        decimal salary = _calculator.Calculate(employee, baseSalary, workedDays);
        string report = $"{employee}: зарплата {salary:N2} грн ({workedDays} днів)";

        _exporter.Export(report);
        _repository.Save(report);
    }
}
