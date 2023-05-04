namespace ProjectCosts.Core.Options;

public record ProjectCostsApiOptions
(
    string BaseUrl,
    string GetSimpleThings,
    string GetSimpleThing,
    string CreateSimpleThing,
    string UpdateSimpleThing
)
{
    public const string ConfigSection = "ProjectCostsApi";
}
