namespace lab21;

// Factory Method: створює потрібну стратегію на основі рядка типу поліса.
public static class InsuranceStrategyFactory
{
    public static IInsuranceStrategy CreateStrategy(string policyType)
    {
        return policyType.Trim().ToLower() switch
        {
            "basic"      => new BasicInsurance(),
            "extended"   => new ExtendedInsurance(),
            "full"       => new FullCoverage(),
            "commercial" => new CommercialInsurance(),   // 4-та стратегія — додана у фабрику
            _ => throw new ArgumentException($"Невідомий тип поліса: '{policyType}'.")
        };
    }
}
