using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSelectedThingReducer : Reducer<SelectedThingState, SetSelectedThingAction>
{
    public override SelectedThingState Reduce(SelectedThingState state, SetSelectedThingAction action)
    {
        return new SelectedThingState
        (
            FetchStatus: FetchingStatus.Loaded,
            Thing: action.Thing
        );
    }
}
