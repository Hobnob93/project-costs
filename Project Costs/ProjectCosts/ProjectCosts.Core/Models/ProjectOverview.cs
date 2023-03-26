using ProjectCosts.Core.Enum;

namespace ProjectCosts.Core.Models;

public class ProjectOverview
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required Cost Cost { get; set; }
    public ProjectType Type { get; set; }
    public DateOnly StartDate { get; set; }
}
