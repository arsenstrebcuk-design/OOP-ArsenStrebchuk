namespace lab3v18;

// Базовий абстрактний клас елемента їжі
public abstract class FoodItem
{
    // Інкапсульовані поля: доступ лише через властивості
    private string _name = string.Empty;
    private double _weight;                // маса порції, г
    protected double _caloriesPer100g;     // калорійність на 100 г (доступна похідним класам)

    // Конструктор базового класу з параметрами
    protected FoodItem(string name, double weight, double caloriesPer100g)
    {
        Name = name;
        Weight = weight;
        _caloriesPer100g = caloriesPer100g;
    }

    public string Name
    {
        get => _name;
        set => _name = string.IsNullOrWhiteSpace(value) ? "Без назви" : value;
    }

    public double Weight
    {
        get => _weight;
        set => _weight = value < 0 ? 0 : value;
    }

    // Калорійність порції з урахуванням її маси
    public double TotalCalories() => _caloriesPer100g * Weight / 100.0;

    // Абстрактний метод: категорію визначає кожен похідний клас окремо
    public abstract string Category();

    // Віртуальний метод: може бути перевизначений у похідних класах
    public virtual string GetInfo()
        => $"{Name} ({Category()}): {Weight} г, {TotalCalories():F0} ккал";

    // Деструктор: спрацьовує при звільненні обʼєкта збирачем сміття
    ~FoodItem()
    {
        Console.WriteLine($"Обʼєкт \"{Name}\" видалено з памʼяті.");
    }
}
