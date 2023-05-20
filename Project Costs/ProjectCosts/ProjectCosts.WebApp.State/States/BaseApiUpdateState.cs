using ProjectCosts.Core.Enum;

namespace ProjectCosts.Web.Store.States;

public abstract record BaseApiUpdateState
(
    FetchingStatus FetchStatus,
    string? FetchError,
    UpdatingStatus UpdateStatus,
    string? UpdateError
) : BaseApiFetchState(FetchStatus, FetchError);
