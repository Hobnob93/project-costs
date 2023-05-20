using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.Actions;

public record SetSelectedThingLoadedAction
(
    ThingOverview? Thing = null,
    string? Error = null
);
