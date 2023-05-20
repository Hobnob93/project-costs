using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSelectedThingLoadedReducer : Reducer<SelectedThingState, SetSelectedThingLoadedAction>
{
    public override SelectedThingState Reduce(SelectedThingState state, SetSelectedThingLoadedAction action)
    {
        if (action.Thing != null)
        {
            return state with
            {
                FetchStatus = FetchingStatus.Loaded,
                FetchError = null,
                Thing = action.Thing
            };
        }

        return state with
        {
            FetchStatus = FetchingStatus.Errored,
            FetchError = action.Error
        };
    }
}
