using OneOf;
using OneOf.Types;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Core.Interfaces;

public interface ISimpleThingClient
{
    Task<OneOf<ThingOverview, NotFound, Error<string>>> GetSimpleThingAsync(string id);
    Task<OneOf<List<ThingOverview>, Error<string>>> GetSimpleThingsAsync();
}
