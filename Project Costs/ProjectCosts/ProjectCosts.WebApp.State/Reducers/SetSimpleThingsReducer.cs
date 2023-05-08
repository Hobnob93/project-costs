using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSimpleThingsReducer : Reducer<SimpleThingsState, SetSimpleThingsAction>
{
    public override SimpleThingsState Reduce(SimpleThingsState state, SetSimpleThingsAction action)
    {
        return new SimpleThingsState
        (
            FetchStatus: FetchingStatus.Loaded,
            Error: null,
            Things: action.Things
        );
    }
}
