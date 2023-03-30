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
            ProjectType.Diy => Icons.Material.Filled.Handyman,
            ProjectType.Event => Icons.Material.Filled.Event,
            ProjectType.Holiday => Icons.Material.Filled.Airlines,
            ProjectType.Other => Icons.Material.Filled.QuestionMark,
            _ => Icons.Material.Filled.Hexagon
        };
    }
}
