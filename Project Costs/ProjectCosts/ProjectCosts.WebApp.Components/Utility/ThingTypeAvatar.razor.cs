using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProjectCosts.Core.Enum;

namespace ProjectCosts.Web.Components.Utility;

public partial class ThingTypeAvatar
{
    [Parameter]
    public ThingType ThingType { get; set; }

    private string GetIcon()
    {
        return ThingType switch
        {
            ThingType.Diy => Icons.Material.Filled.Handyman,
            ThingType.Event => Icons.Material.Filled.Event,
            ThingType.Holiday => Icons.Material.Filled.AirplaneTicket,
            ThingType.Birthday => Icons.Material.Filled.Cake,
            ThingType.Christmas => Icons.Material.Filled.CardGiftcard,
            ThingType.Other => Icons.Material.Filled.QuestionMark,
            _ => Icons.Material.Filled.Hexagon
        };
    }
}
