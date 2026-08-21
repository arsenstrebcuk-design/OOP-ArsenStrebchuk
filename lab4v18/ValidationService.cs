namespace lab4v18;

// Сервіс перевірки даних
public class ValidationService
{
    // АГРЕГАЦІЯ: валідатор створюється ЗЗОВНІ й передається в конструктор
    // (сервіс лише користується ним, але не володіє його життєвим циклом)
    private readonly IValidator _validator;

    // КОМПОЗИЦІЯ: список невалідних значень сервіс створює й тримає сам
    // (ця частина існує лише в межах сервісу)
    private readonly List<string> _invalidValues = new List<string>();

    public ValidationService(IValidator validator)
    {
        _validator = validator;
    }

    public string ValidatorName => _validator.Name;

    // Перевіряє список і повертає відсоток валідних значень
    public double ValidPercentage(List<string> values)
    {
        _invalidValues.Clear();
        if (values.Count == 0)
            return 0;

        int valid = 0;
        foreach (string value in values)
        {
            if (_validator.IsValid(value))
                valid++;
            else
                _invalidValues.Add(value);
        }

        return (double)valid / values.Count * 100;
    }

    // Тільки для читання: зібрані невалідні значення
    public IReadOnlyList<string> InvalidValues => _invalidValues;
}
