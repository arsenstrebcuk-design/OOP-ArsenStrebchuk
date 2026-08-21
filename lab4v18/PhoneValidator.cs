namespace lab4v18;

// Реалізація №2: перевірка номера телефону
public class PhoneValidator : ValidatorBase
{
    public override string Name => "Телефон";

    // Прибираємо роздільники й перевіряємо, що лишились 10–13 цифр
    protected override bool Check(string value)
    {
        string digits = value;
        foreach (char symbol in "+-() ")
            digits = digits.Replace(symbol.ToString(), "");

        if (digits.Length < 10 || digits.Length > 13)
            return false;

        foreach (char c in digits)
            if (!char.IsDigit(c))
                return false;

        return true;
    }
}
