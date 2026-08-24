namespace lab20;

// Координує роботу компонентів (валідатор, репозиторій, email).
// Залежності отримує через конструктор — Dependency Injection.
// Сам OrderService не знає деталей реалізації, лише інтерфейси.
public class OrderService
{
    private readonly IOrderValidator _validator;
    private readonly IOrderRepository _repository;
    private readonly IEmailService _emailService;

    public OrderService(
        IOrderValidator validator,
        IOrderRepository repository,
        IEmailService emailService)
    {
        _validator = validator;
        _repository = repository;
        _emailService = emailService;
    }

    public void ProcessOrder(Order order)
    {
        order.Status = OrderStatus.PendingValidation;

        if (!_validator.IsValid(order))
        {
            order.Status = OrderStatus.Cancelled;
            Console.WriteLine(
                $"[OrderService] Замовлення #{order.Id} відхилено: сума {order.TotalAmount} некоректна. " +
                $"Статус = {order.Status}.");
            return;
        }

        _repository.Save(order);
        _emailService.SendOrderConfirmation(order);

        order.Status = OrderStatus.Processed;
        Console.WriteLine($"[OrderService] Замовлення #{order.Id} оброблено. Статус = {order.Status}.");
    }
}
