using ProjectCosts.Core.Enum;

namespace ProjectCosts.Core.Models;

public class ThingOverview
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required Cost Cost { get; set; }
    public string? Image { get; set; }
    public ThingType Type { get; set; }
    public DateOnly StartDate { get; set; }
}
