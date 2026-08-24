namespace lab20;

// Єдина відповідальність: збереження / отримання замовлень
public interface IOrderRepository
{
    void Save(Order order);
    Order? GetById(int id);
}
