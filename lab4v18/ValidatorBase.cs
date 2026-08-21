namespace lab4v18;

// Абстрактний базовий клас реалізує інтерфейс IValidator
// та задає спільну логіку для всіх валідаторів
public abstract class ValidatorBase : IValidator
{
    // Назву визначає кожен конкретний валідатор
    public abstract string Name { get; }

    // Спільна перевірка: порожнє значення завжди невалідне,
    // решту перевіряє конкретна реалізація в методі Check
    public bool IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return false;
        return Check(value.Trim());
    }

    // Правило перевірки, яке реалізує кожен похідний клас окремо
    protected abstract bool Check(string value);
}
