using ProjectCosts.Core.Enum;

namespace ProjectCosts.Core.Models;

public class CreateThingData
{
    public required string Name { get; set; }
    public string? Image { get; set; }
    public ThingType Type { get; set; }
    public DateOnly StartDate { get; set; }
}
