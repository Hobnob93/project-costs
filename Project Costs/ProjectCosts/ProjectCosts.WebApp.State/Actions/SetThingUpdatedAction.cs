using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.Actions;

public record SetThingUpdatedAction
(
    ThingOverview? Thing = null,
    string? Error = null
);
