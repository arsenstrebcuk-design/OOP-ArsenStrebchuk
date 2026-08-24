namespace lab23.Initial;

// Низькорівневий клас: розрахунок зарплати
public class SalaryCalculator
{
    public decimal Calculate(string employee, decimal baseSalary, int workedDays)
        => baseSalary / 22 * workedDays;   // пропорційно відпрацьованим дням (з 22 робочих)
}

// "Товстий" експортер: PayrollSystem потребує лише PDF, але клас несе купу зайвого (ISP).
public class PdfExporter
{
    public void ExportToPdf(string content) => Console.WriteLine($"[PDF] Згенеровано звіт: {content}");
    public void ExportToExcel(string content) => Console.WriteLine($"[Excel] {content}"); // не потрібно PayrollSystem
    public void Print(string content) => Console.WriteLine($"[Printer] {content}");        // не потрібно PayrollSystem
}

// "Товста" БД: PayrollSystem потребує лише Save, решта — зайве навантаження (ISP).
public class SqlDatabase
{
    public void Save(string data) => Console.WriteLine($"[SQL] Збережено в БД: {data}");
    public string Load(int id) => $"record#{id}";          // не потрібно PayrollSystem
    public void Delete(int id) => Console.WriteLine($"[SQL] Видалено #{id}");  // не потрібно
    public void Backup() => Console.WriteLine("[SQL] Резервна копія");         // не потрібно
}

// Головний клас: СТВОРЮЄ власні залежності всередині себе (жорсткий зв'язок => порушення DIP)
// і залежить від конкретних "товстих" класів (порушення ISP).
public class PayrollSystem
{
    private readonly SalaryCalculator _calculator = new SalaryCalculator();
    private readonly PdfExporter _exporter = new PdfExporter();   // DIP: пряма залежність від конкретики
    private readonly SqlDatabase _database = new SqlDatabase();   // DIP: пряма залежність від конкретики

    public void ProcessPayroll(string employee, decimal baseSalary, int workedDays)
    {
        decimal salary = _calculator.Calculate(employee, baseSalary, workedDays);
        string report = $"{employee}: зарплата {salary:N2} грн ({workedDays} днів)";

        _exporter.ExportToPdf(report);   // з усього PdfExporter тут треба лише це
        _database.Save(report);          // з усього SqlDatabase тут треба лише це
    }
}
