using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Components.Home;

public partial class ThingCard
{
    [Parameter, EditorRequired]
    public ThingOverview Thing { get; set; } = default!;

    public string ThingImage => Thing.Image ?? "images/unknown.jpg";
}
