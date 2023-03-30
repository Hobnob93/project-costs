using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Components.Utility;

public partial class CostDisplay
{
    [Parameter, EditorRequired]
    public Cost Cost { get; set; } = default!;

    private string CostAsString()
    {
        if (Cost.Estimate is null)
            return $"£{Cost.Value:0}";

        var estimate = Cost.Estimate;
        return $"£{estimate.LowerEstimate:0} - £{estimate.UpperEstimate:0}";
    }
}
