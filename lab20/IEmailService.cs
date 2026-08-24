namespace lab20;

// Єдина відповідальність: надсилання листів
public interface IEmailService
{
    void SendOrderConfirmation(Order order);
}
