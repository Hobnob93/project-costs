using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSimpleThingsErrorReducer : Reducer<SimpleThingsState, SetSimpleThingsErrorAction>
{
    public override SimpleThingsState Reduce(SimpleThingsState state, SetSimpleThingsErrorAction action)
    {
        return new SimpleThingsState
        (
            FetchStatus: FetchingStatus.Errored,
            Error: action.Error,
            Things: Array.Empty<ThingOverview>()
        );
    }
}
