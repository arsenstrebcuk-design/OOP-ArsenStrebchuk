namespace lab20;

// Заглушка email-сервісу: "надсилає" лист у консоль
public class ConsoleEmailService : IEmailService
{
    public void SendOrderConfirmation(Order order)
        => Console.WriteLine($"[Email] Підтвердження надіслано {order.CustomerName} щодо замовлення #{order.Id}.");
}
