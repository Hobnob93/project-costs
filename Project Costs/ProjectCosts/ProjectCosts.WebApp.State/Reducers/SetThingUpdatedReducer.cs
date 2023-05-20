using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetThingUpdatedReducer : Reducer<SelectedThingState, SetThingUpdatedAction>
{
    public override SelectedThingState Reduce(SelectedThingState state, SetThingUpdatedAction action)
    {
        if (action.Thing != null)
        {
            return state with
            {
                UpdateStatus = UpdatingStatus.Updated,
                UpdateError = null,
                Thing = action.Thing
            };
        }

        return state with
        {
            UpdateStatus = UpdatingStatus.Errored,
            UpdateError = action.Error
        };
    }
}
