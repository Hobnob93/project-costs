using Fluxor;
using ProjectCosts.Core.Interfaces;
using ProjectCosts.Web.Store.Actions;

namespace ProjectCosts.Web.Store.Effects;

public class SelectThingEffect : Effect<SelectThingAction>
{
    private readonly ISimpleThingClient _simpleThingClient;

    public SelectThingEffect(ISimpleThingClient simpleThingClient)
    {
        _simpleThingClient = simpleThingClient;
    }

    public override async Task HandleAsync(SelectThingAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetSelectedThingLoadingAction());

        var result = await _simpleThingClient.GetSimpleThingAsync(action.ThingId);
        var nextAction = result.Match<object>
        (
            thing => new SetSelectedThingAction(thing),
            notFound => new SetSelectedThingErrorAction($"Item with ID '{action.ThingId}' could not be found."),
            error => new SetSelectedThingErrorAction(error.Value)
        );

        dispatcher.Dispatch(nextAction);
    }
}
