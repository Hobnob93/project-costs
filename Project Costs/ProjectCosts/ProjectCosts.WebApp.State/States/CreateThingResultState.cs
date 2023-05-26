using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record CreateThingResultState(
    ThingOverview? CreatedThing,
    UpdatingStatus CreateStatus,
    string? CreateError
);
