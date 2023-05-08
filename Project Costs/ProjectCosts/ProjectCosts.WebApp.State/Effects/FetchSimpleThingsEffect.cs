using Fluxor;
using ProjectCosts.Core.Interfaces;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.Actions;

namespace ProjectCosts.Web.Store.Effects;

public class FetchSimpleThingsEffect : Effect<FetchSimpleThingsAction>
{
    private readonly ISimpleThingClient _simpleThingClient;

    public FetchSimpleThingsEffect(ISimpleThingClient simpleThingClient)
    {
        _simpleThingClient = simpleThingClient;
    }

    public override async Task HandleAsync(FetchSimpleThingsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetSimpleThingsLoadingAction());

        var result = await _simpleThingClient.GetSimpleThingsAsync();
        var nextAction = result.Match<object>
        (
            things => new SetSimpleThingsAction(things.ToArray()),
            error => new SetSimpleThingsErrorAction(error.Value)
        );

        dispatcher.Dispatch(nextAction);
    }
}
