using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class SetSimpleThingsLoadingReducer : Reducer<SimpleThingsState, SetSimpleThingsLoadingAction>
{
    public override SimpleThingsState Reduce(SimpleThingsState state, SetSimpleThingsLoadingAction action)
    {
        return new SimpleThingsState
        (
            FetchStatus: FetchingStatus.Loading,
            FetchError: null,
            Things: Array.Empty<ThingOverview>()
        );
    }
}
