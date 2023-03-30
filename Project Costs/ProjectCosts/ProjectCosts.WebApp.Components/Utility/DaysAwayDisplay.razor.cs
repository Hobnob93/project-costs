using Microsoft.AspNetCore.Components;

namespace ProjectCosts.Web.Components.Utility;

public partial class DaysAwayDisplay
{
    [Parameter, EditorRequired]
    public DateOnly Date { get; set; }

    private int DaysAwayFromNow()
    {
        var now = DateOnly.FromDateTime(DateTime.Now);
        return Date.DayNumber - now.DayNumber;
    }
}
