using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Pages;

public partial class Edit : FluxorComponent
{
    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IState<SelectedThingState> SelectedThingState { get; set; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private ThingOverview? SelectedThing => SelectedThingState.Value.Thing;
    private FetchingStatus FetchStatus => SelectedThingState.Value.FetchStatus;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (string.IsNullOrWhiteSpace(Id))
            return;

        Dispatcher.Dispatch(new SelectThingAction(Id));
    }
}
