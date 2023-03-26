namespace ProjectCosts.Core.Models;

public class Cost
{
    public Estimate? Estimate { get; set; }
    public decimal Value { get; set; }

    public override string ToString()
    {
        if (Estimate == null)
            return Value.ToString("0.00");

        return $"{Estimate.LowerEstimate:0.00} - {Estimate.UpperEstimate:0.00}";
    }
}
