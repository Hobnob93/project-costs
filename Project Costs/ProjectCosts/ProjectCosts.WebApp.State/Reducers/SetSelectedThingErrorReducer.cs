using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSelectedThingErrorReducer : Reducer<SelectedThingState, SetSelectedThingErrorAction>
{
    public override SelectedThingState Reduce(SelectedThingState state, SetSelectedThingErrorAction action)
    {
        return state with
        {
            FetchStatus = FetchingStatus.Errored,
            Error = action.Error,
            Thing = null
        };
    }
}
