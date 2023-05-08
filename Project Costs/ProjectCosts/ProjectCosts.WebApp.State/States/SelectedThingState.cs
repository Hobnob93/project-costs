using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record SelectedThingState(FetchingStatus FetchStatus, string? Error, ThingOverview? Thing)
    : BaseApiFetchState(FetchStatus, Error);
