using InitialPayroll = lab23.Initial.PayrollSystem;
using lab23.Refactored;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("======== ПОЧАТКОВА СТРУКТУРА (порушує ISP та DIP) ========\n");
Console.WriteLine("PayrollSystem сам створює свої залежності всередині себе:\n");

InitialPayroll initial = new InitialPayroll();   // жодних залежностей ззовні — усе всередині
initial.ProcessPayroll("Іван Петренко", 22000m, 20);

Console.WriteLine("\nПрацює, але жорстко зв'язано: не підмінити БД/експортер, не протестувати ізольовано.");


Console.WriteLine("\n\n======== РЕФАКТОРИНГ (ISP + DIP через конструктор) ========\n");

// DIP: залежності створюються ЗЗОВНІ і вводяться через конструктор
ISalaryCalculator calculator = new SalaryCalculator();
IReportExporter exporter = new PdfExporter();
IReportRepository repository = new SqlReportRepository();

PayrollSystem payroll = new PayrollSystem(calculator, exporter, repository);
payroll.ProcessPayroll("Іван Петренко", 22000m, 20);

Console.WriteLine("\n=== Підміна реалізацій БЕЗ зміни PayrollSystem ===");
Console.WriteLine("Той самий клас, інші залежності (Console-експорт + In-memory БД):\n");

PayrollSystem payroll2 = new PayrollSystem(
    new SalaryCalculator(),
    new ConsoleReportExporter(),
    new InMemoryReportRepository());

payroll2.ProcessPayroll("Олена Коваль", 30000m, 22);
