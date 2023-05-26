using Fluxor;
using Fluxor.Blazor.Web.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ProjectCosts.Core.Models;
using ProjectCosts.Core.Services;
using ProjectCosts.Web.Components.ViewModel;
using ProjectCosts.Web.Store.Actions;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Pages;

public partial class Edit : FluxorComponent
{
    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IState<SelectedThingState> SelectedThingState { get; set; } = default!;

    [Inject]
    private Navigation Navigation { get; set; } = default!;

    [Parameter]
    public string Id { get; set; } = string.Empty;

    private EditThingViewModel? _formModel;
    private ThingOverview? SelectedThing => SelectedThingState.Value.Thing;


    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (string.IsNullOrWhiteSpace(Id))
            return;

        Dispatcher.Dispatch(new SelectThingAction(Id));

        SelectedThingState.StateChanged += OnSelectedThingStateChanged;     // FluxorComponent handles unsubscribing
    }

    private void OnSelectedThingStateChanged(object? sender, EventArgs e)
    {
        if (SelectedThing is null)
            return;

        _formModel = new EditThingViewModel
        { 
            Id = SelectedThing.Id,
            Name = SelectedThing.Name,
            Image = SelectedThing.Image,
            StartDate = SelectedThing.StartDate.ToDateTime(TimeOnly.MinValue),
            Type = SelectedThing.Type
        };

        StateHasChanged();
    }

    private void OnValidSubmit(EditContext context)
    {
        var updateData = new UpdateThingData
        {
            Id = _formModel!.Id,
            Name = _formModel.Name!,
            Image = _formModel.Image,
            StartDate = DateOnly.FromDateTime(_formModel.StartDate!.Value),
            Type = _formModel.Type
        };

        Dispatcher.Dispatch(new UpdateThingAction(updateData));
    }

    private void CancelClicked()
    {
        Navigation.NavigateBack();
    }
}
