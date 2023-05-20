using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Components.Utility;

public partial class ApiFetchDisplay
{
    [Parameter, EditorRequired]
    public BaseApiFetchState FetchState { get; set; } = default!;

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = default!;

    [Parameter]
    public Func<bool>? DisplayPredicate { get; set; }

    private FetchingStatus Status => FetchState.FetchStatus;
    private string? Error => FetchState.FetchError;

    private bool ExtraCheckIsSuccess()
    {
        if (DisplayPredicate == null)
            return true;

        return DisplayPredicate.Invoke();
    }
}