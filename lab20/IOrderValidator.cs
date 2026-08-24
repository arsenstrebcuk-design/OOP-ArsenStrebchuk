namespace lab20;

// Єдина відповідальність: валідація замовлення
public interface IOrderValidator
{
    bool IsValid(Order order);
}
