using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSelectedThingLoadingReducer : Reducer<SelectedThingState, SetSelectedThingLoadingAction>
{
    public override SelectedThingState Reduce(SelectedThingState state, SetSelectedThingLoadingAction action)
    {
        return new SelectedThingState
        (
            FetchStatus: FetchingStatus.Loading,
            FetchError: null,
            UpdateStatus: UpdatingStatus.NotStarted,
            UpdateError: null,
            Thing: null
        );
    }
}
