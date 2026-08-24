namespace lab20;

// Реалізація валідатора: сума замовлення має бути додатною
public class OrderValidator : IOrderValidator
{
    public bool IsValid(Order order) => order.TotalAmount > 0;
}
