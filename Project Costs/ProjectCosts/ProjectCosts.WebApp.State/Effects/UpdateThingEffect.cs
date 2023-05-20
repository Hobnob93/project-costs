using Fluxor;
using ProjectCosts.Core.Interfaces;
using ProjectCosts.Web.Store.Actions;

namespace ProjectCosts.Web.Store.Effects;

public class UpdateThingEffect : Effect<UpdateThingAction>
{
    private readonly ISimpleThingClient _simpleThingClient;

    public UpdateThingEffect(ISimpleThingClient simpleThingClient)
    {
        _simpleThingClient = simpleThingClient;
    }

    public override async Task HandleAsync(UpdateThingAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetThingUpdatingAction());

        var result = await _simpleThingClient.UpdateThingAsync(action.UpdateData);
        var nextAction = result.Match<object>
        (
            thing => new SetThingUpdatedAction(Thing: thing),
            notFound => new SetThingUpdatedAction(Error: $"Item with ID '{action.UpdateData.Id}' could not be found."),
            error => new SetThingUpdatedAction(Error: error.Value)
        );

        dispatcher.Dispatch(nextAction);
    }
}
