using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using ProjectCosts.Core.Services;
using ProjectCosts.Web.Components.ViewModel;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Pages;

public partial class New : FluxorComponent
{
    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IState<CreateThingResultState> CreateResultState { get; set; } = default!;

    [Inject]
    private Navigation Navigation { get; set; } = default!;

    private EditThingViewModel _formModel = new();
    private UpdatingStatus CreateStatus => CreateResultState.Value.CreateStatus;
    private string? CreateError => CreateResultState.Value.CreateError;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _formModel = new();
    }

    private void OnValidSubmit(EditContext context)
    {
        var createData = new CreateThingData
        {
            Name = _formModel.Name!,
            Image = _formModel.Image,
            StartDate = DateOnly.FromDateTime(_formModel.StartDate!.Value),
            Type = _formModel.Type
        };

        Dispatcher.Dispatch(new CreateThingAction(createData));
    }

    private void CancelClicked()
    {
        Navigation.NavigateBack();
    }
}
