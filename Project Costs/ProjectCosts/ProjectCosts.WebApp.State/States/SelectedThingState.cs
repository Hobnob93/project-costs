using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record SelectedThingState(FetchingStatus FetchStatus, ThingOverview? Thing);
