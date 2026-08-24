namespace lab23.Refactored;

// ISP: вузькі, вузькоспеціалізовані інтерфейси — лише те, що реально потрібно клієнту.

public interface ISalaryCalculator
{
    decimal Calculate(string employee, decimal baseSalary, int workedDays);
}

public interface IReportExporter
{
    void Export(string content);   // тільки експорт звіту, нічого зайвого
}

public interface IReportRepository
{
    void Save(string data);        // тільки збереження, без Load/Delete/Backup
}
