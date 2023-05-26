using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.Actions;

public record CreateThingResultAction(
    UpdatingStatus CreateStatus,
    ThingOverview? CreatedThing = null,
    string? CreateError = null
);
