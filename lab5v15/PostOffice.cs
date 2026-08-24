namespace lab5v15;

// Сутність: поштове відділення
public class PostOffice
{
    public string Name { get; }

    // Композиція: відділення створює й володіє сховищем відправлень
    private readonly Repository<Shipment> _repository = new Repository<Shipment>();

    public PostOffice(string name)
    {
        Name = name;
    }

    public void Register(Shipment shipment) => _repository.Add(shipment);

    public IReadOnlyList<Shipment> Shipments => _repository.All();

    // Пошук відправлення за трек-номером (може кинути NotFoundException)
    public Shipment FindByTracking(string trackingNumber)
        => _repository.Find(s => s.TrackingNumber == trackingNumber);

    // Середній термін доставки (лише серед доставлених)
    public double AverageDeliveryDays()
    {
        List<Shipment> delivered = _repository.Where(s => s.Status == ShipmentStatus.Delivered);
        if (delivered.Count == 0)
            return 0;
        return delivered.Average(s => s.DeliveryDays);
    }

    // Частка втрачених або пошкоджених відправлень, %
    public double LostOrDamagedFraction()
    {
        IReadOnlyList<Shipment> all = _repository.All();
        if (all.Count == 0)
            return 0;
        int bad = _repository.Where(s =>
            s.Status == ShipmentStatus.Lost ||
            s.Status == ShipmentStatus.Damaged).Count;
        return (double)bad / all.Count * 100;
    }

    // Топ-N напрямків за кількістю відправлень (використовує узагальнений TopN)
    public List<string> TopDestinations(int n)
    {
        var grouped = _repository.All()
            .GroupBy(s => s.Destination)
            .Select(g => new { Destination = g.Key, Count = g.Count() });

        return CollectionUtils.TopN(grouped, n, d => d.Count)
            .Select(d => $"{d.Destination} — {d.Count} відпр.")
            .ToList();
    }
}
