using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Pages;

public partial class Index : FluxorComponent
{
    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IState<SimpleThingsState> State { get; set; } = default!;

    private ThingOverview[] Things => State.Value.Things;
    private FetchingStatus FetchStatus => State.Value.FetchStatus;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Dispatcher.Dispatch(new FetchSimpleThingsAction());
    }
}
