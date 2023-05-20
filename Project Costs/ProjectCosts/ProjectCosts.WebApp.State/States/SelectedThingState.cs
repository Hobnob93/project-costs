using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record SelectedThingState
(
    FetchingStatus FetchStatus,
    string? FetchError,
    UpdatingStatus UpdateStatus,
    string? UpdateError,
    ThingOverview? Thing
) : BaseApiUpdateState(FetchStatus, FetchError, UpdateStatus, UpdateError);
