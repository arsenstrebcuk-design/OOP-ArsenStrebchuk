namespace lab5v15;

// Сутність: окреме поштове відправлення
public class Shipment
{
    public string TrackingNumber { get; }
    public string Destination { get; }
    public DateTime SentDate { get; }
    public DateTime DeliveredDate { get; }
    public ShipmentStatus Status { get; }

    public Shipment(string trackingNumber, string destination,
                    DateTime sentDate, DateTime deliveredDate, ShipmentStatus status)
    {
        // Валідація вхідних даних: дата доставки не може бути раніше відправлення
        if (deliveredDate < sentDate)
            throw new InvalidShipmentDatesException(
                $"Відправлення {trackingNumber}: дата доставки раніше дати відправлення.");

        TrackingNumber = trackingNumber;
        Destination = destination;
        SentDate = sentDate;
        DeliveredDate = deliveredDate;
        Status = status;
    }

    // Термін доставки у днях
    public int DeliveryDays => (DeliveredDate - SentDate).Days;
}
