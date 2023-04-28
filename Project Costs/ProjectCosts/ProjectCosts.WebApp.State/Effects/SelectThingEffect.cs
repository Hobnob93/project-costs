using Fluxor;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.Actions;

namespace ProjectCosts.Web.Store.Effects;

public class SelectThingEffect : Effect<SelectThingAction>
{
    public override async Task HandleAsync(SelectThingAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new SetSelectedThingLoadingAction());

        await Task.Delay(1000); // TODO: Call API to get thing by id

        dispatcher.Dispatch(new SetSelectedThingAction(new ThingOverview
        {
            Id = action.ThingId,
            Name = "Test Thing",
            Image = "https://via.placeholder.com/150",
            StartDate = DateOnly.FromDateTime(DateTime.Now),
            Cost = new Cost()
            {
                Value = 100m
            }
        }));
    }
}
