using ProjectCosts.Core.Enum;

namespace ProjectCosts.Web.Store.States;

public abstract record BaseApiFetchState(FetchingStatus FetchStatus, string? Error);
