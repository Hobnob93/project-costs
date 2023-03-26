using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Components.Home;

public partial class ProjectCard
{
    [Parameter, EditorRequired]
    public ProjectOverview Project { get; set; } = default!;

    public string ProjectImage => Project.Image ?? "images/unknown.jpg";
}
