using Microsoft.AspNetCore.Components;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Components.Utility;

public partial class ApiUpdateTmp
{
    [Parameter, EditorRequired]
    public BaseApiUpdateState UpdateState { get; set; } = default!;

    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = default!;

    private UpdatingStatus Status => UpdateState.UpdateStatus;
    private string? Error => UpdateState.UpdateError;
}