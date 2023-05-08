using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record SimpleThingsState(FetchingStatus FetchStatus, string? Error, ThingOverview[] Things)
    : BaseApiFetchState(FetchStatus, Error);
