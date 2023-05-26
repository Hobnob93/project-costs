using Fluxor;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Reducers;

public class CreateThingResultReducer : Reducer<CreateThingResultState, CreateThingResultAction>
{
    public override CreateThingResultState Reduce(CreateThingResultState state, CreateThingResultAction action)
    {
        return new CreateThingResultState(
            CreatedThing: action.CreatedThing,
            CreateStatus: action.CreateStatus,
            CreateError: action.CreateError
        );
    }
}
