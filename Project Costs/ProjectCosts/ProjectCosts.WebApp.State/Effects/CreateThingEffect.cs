using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Interfaces;
using ProjectCosts.Core.Models;
using ProjectCosts.Core.Services;
using ProjectCosts.Web.Store.Actions;

namespace ProjectCosts.Web.Store.Effects;

public class CreateThingEffect : Effect<CreateThingAction>
{
    private readonly ISimpleThingClient _simpleThingClient;
    private readonly Navigation _navigation;

    public CreateThingEffect(ISimpleThingClient simpleThingClient, Navigation navigation)
    {
        _simpleThingClient = simpleThingClient;
        _navigation = navigation;
    }

    public override async Task HandleAsync(CreateThingAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new CreateThingResultAction(CreateStatus: UpdatingStatus.Updating));

        var result = await _simpleThingClient.CreateThingAsync(action.CreateData);
        var nextAction = result.Match<object>
        (
            thing => new CreateThingResultAction(CreateStatus: UpdatingStatus.Updated, CreatedThing: thing),
            error => new CreateThingResultAction(CreateStatus: UpdatingStatus.Errored, CreateError: error.Value)
        );

        dispatcher.Dispatch(nextAction);

        if (result.Value is ThingOverview createdThing)
        {
            // Wait a while so user can see success message
            await Task.Delay(1000);

            _navigation.NavigateTo($"/things/{createdThing.Id}");
        }
    }
}
