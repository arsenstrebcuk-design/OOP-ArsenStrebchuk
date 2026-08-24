namespace lab23.Refactored;

// Реалізації вузьких інтерфейсів.

public class SalaryCalculator : ISalaryCalculator
{
    public decimal Calculate(string employee, decimal baseSalary, int workedDays)
        => baseSalary / 22 * workedDays;
}

public class PdfExporter : IReportExporter
{
    public void Export(string content) => Console.WriteLine($"[PDF] Згенеровано звіт: {content}");
}

public class SqlReportRepository : IReportRepository
{
    public void Save(string data) => Console.WriteLine($"[SQL] Збережено в БД: {data}");
}

// Альтернативні реалізації — щоб показати гнучкість DIP (підміна без зміни PayrollSystem).
public class ConsoleReportExporter : IReportExporter
{
    public void Export(string content) => Console.WriteLine($"[Console] {content}");
}

public class InMemoryReportRepository : IReportRepository
{
    private readonly List<string> _storage = new List<string>();
    public void Save(string data)
    {
        _storage.Add(data);
        Console.WriteLine($"[Memory] Збережено в пам'ять (усього записів: {_storage.Count})");
    }
}
