namespace lab3v18;

// Похідний клас: фрукт
public class Fruit : FoodItem
{
    private bool _isSweet;   // ознака солодкості

    // Конструктор викликає базовий через base(...)
    public Fruit(string name, double weight, double caloriesPer100g, bool isSweet)
        : base(name, weight, caloriesPer100g)
    {
        _isSweet = isSweet;
    }

    // Реалізація абстрактного методу базового класу
    public override string Category() => "Фрукт";

    // Перевизначення віртуального методу з доповненням базового результату
    public override string GetInfo()
        => base.GetInfo() + (_isSweet ? ", солодкий" : ", несолодкий");
}
