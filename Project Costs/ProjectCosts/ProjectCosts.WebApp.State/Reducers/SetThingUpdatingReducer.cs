using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetThingUpdatingReducer : Reducer<SelectedThingState, SetThingUpdatingAction>
{
    public override SelectedThingState Reduce(SelectedThingState state, SetThingUpdatingAction action)
    {
        return state with
        {
            UpdateError = null,
            UpdateStatus = UpdatingStatus.Updating
        };
    }
}
