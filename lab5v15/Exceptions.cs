namespace lab5v15;

// Виняток: дата доставки раніше дати відправлення
public class InvalidShipmentDatesException : Exception
{
    public InvalidShipmentDatesException(string message) : base(message) { }
}

// Виняток: елемент не знайдено у сховищі
public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}
