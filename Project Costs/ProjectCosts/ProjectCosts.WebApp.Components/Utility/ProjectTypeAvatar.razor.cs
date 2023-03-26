using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProjectCosts.Core.Enum;

namespace ProjectCosts.Web.Components.Utility;

public partial class ProjectTypeAvatar
{
    [Parameter]
    public ProjectType ProjectType { get; set; }

    private string GetIcon()
    {
        return ProjectType switch
        {
            ProjectType.House => Icons.Material.Filled.House,
            ProjectType.Event => Icons.Material.Filled.Event,
            ProjectType.Other => Icons.Material.Filled.QuestionMark,
            _ => Icons.Material.Filled.Money
        };
    }
}
