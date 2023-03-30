using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Pages;

public partial class Index : FluxorComponent
{
    [Inject]
    private IState<HomeState> State { get; set; } = default!;
}
