namespace lab4v18;

// Реалізація №1: перевірка електронної пошти
public class EmailValidator : ValidatorBase
{
    public override string Name => "Email";

    // Проста перевірка: наявність '@' та крапки після нього
    protected override bool Check(string value)
    {
        int at = value.IndexOf('@');
        int dot = value.LastIndexOf('.');
        return at > 0 && dot > at + 1 && dot < value.Length - 1;
    }
}
