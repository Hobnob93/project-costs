using Microsoft.AspNetCore.Components;

namespace ProjectCosts.Web.Components.Utility;

public partial class DateDisplay
{
    [Parameter, EditorRequired]
    public DateOnly Date { get; set; }
}
