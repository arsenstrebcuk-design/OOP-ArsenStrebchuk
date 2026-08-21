using lab4v18;

// Коректне відображення кирилиці в консолі
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Списки даних для перевірки
List<string> emails = new List<string>
{
    "ivan@gmail.com",
    "test.user@ukr.net",
    "bad-email",
    "no@dot",
    "@wrong.com"
};

List<string> phones = new List<string>
{
    "+380501234567",
    "0671112233",
    "12345",
    "+38 (050) 123-45-67",
    "abcdef"
};

// Агрегація: валідатори створюємо окремо й передаємо в сервіси
IValidator emailValidator = new EmailValidator();
IValidator phoneValidator = new PhoneValidator();

ValidationService emailService = new ValidationService(emailValidator);
ValidationService phoneService = new ValidationService(phoneValidator);

CheckList(emailService, emails);
CheckList(phoneService, phones);

// Вивід результату перевірки одного списку
void CheckList(ValidationService service, List<string> data)
{
    double percent = service.ValidPercentage(data);
    Console.WriteLine($"=== Валідатор: {service.ValidatorName} ===");
    Console.WriteLine($"Перевірено значень: {data.Count}");
    Console.WriteLine($"Валідних: {percent:F1}%");
    if (service.InvalidValues.Count > 0)
        Console.WriteLine($"Невалідні: {string.Join(", ", service.InvalidValues)}");
    Console.WriteLine();
}
