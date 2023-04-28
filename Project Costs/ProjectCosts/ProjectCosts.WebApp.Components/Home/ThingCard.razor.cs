using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Components.Home;

public partial class ThingCard
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Parameter, EditorRequired]
    public ThingOverview Thing { get; set; } = default!;

    public string ThingImage => Thing.Image ?? "images/unknown.jpg";

    private void NavigateToEdit()
    {
        NavigationManager.NavigateTo($"./edit/{Thing.Id}");
    }
}
