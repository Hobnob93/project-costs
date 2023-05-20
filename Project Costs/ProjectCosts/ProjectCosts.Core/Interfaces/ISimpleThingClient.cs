using OneOf;
using OneOf.Types;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Core.Interfaces;

public interface ISimpleThingClient
{
    Task<OneOf<Success, NotFound, Error<string>>> DeleteThingAsync(string id);
    Task<OneOf<ThingOverview, NotFound, Error<string>>> GetSimpleThingAsync(string id);
    Task<OneOf<List<ThingOverview>, Error<string>>> GetSimpleThingsAsync();
    Task<OneOf<ThingOverview, NotFound, Error<string>>> UpdateThingAsync(UpdateThingData updateData);
}
