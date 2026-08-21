namespace lab3v18;

// Похідний клас: мʼясо
public class Meat : FoodItem
{
    private double _proteinPer100g;   // вміст білка на 100 г

    // Конструктор викликає базовий через base(...)
    public Meat(string name, double weight, double caloriesPer100g, double proteinPer100g)
        : base(name, weight, caloriesPer100g)
    {
        _proteinPer100g = proteinPer100g;
    }

    // Реалізація абстрактного методу базового класу
    public override string Category() => "М'ясо";

    // Перевизначення віртуального методу: додаємо кількість білка в порції
    public override string GetInfo()
        => base.GetInfo() + $", білок {_proteinPer100g * Weight / 100.0:F0} г";
}
