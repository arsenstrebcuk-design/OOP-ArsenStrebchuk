namespace lab20;

// ПОЧАТКОВА версія — навмисно ПОРУШУЄ SRP.
// Один клас відповідає одразу за все: валідацію, збереження,
// надсилання email і оновлення статусу. Залишено для порівняння "до/після".
public class OrderProcessor
{
    public void ProcessOrder(Order order)
    {
        // 1. Валідація
        if (order.TotalAmount <= 0)
        {
            Console.WriteLine($"[OrderProcessor] Замовлення #{order.Id} невалідне (сума {order.TotalAmount}).");
            order.Status = OrderStatus.Cancelled;
            return;
        }

        // 2. Збереження в "базу даних"
        Console.WriteLine($"[OrderProcessor] Замовлення #{order.Id} збережено в БД.");

        // 3. Відправка email
        Console.WriteLine($"[OrderProcessor] Email-підтвердження надіслано клієнту {order.CustomerName}.");

        // 4. Оновлення статусу
        order.Status = OrderStatus.Processed;
        Console.WriteLine($"[OrderProcessor] Статус замовлення #{order.Id} = {order.Status}.");
    }
}
