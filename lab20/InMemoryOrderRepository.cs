namespace lab20;

// Заглушка репозиторію: зберігає замовлення у пам'яті
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<int, Order> _orders = new();

    public void Save(Order order)
    {
        _orders[order.Id] = order;
        Console.WriteLine($"[Repository] Замовлення #{order.Id} збережено (у пам'яті).");
    }

    public Order? GetById(int id)
        => _orders.TryGetValue(id, out Order? order) ? order : null;
}
