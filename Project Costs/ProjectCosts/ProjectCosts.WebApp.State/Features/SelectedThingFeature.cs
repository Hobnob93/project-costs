using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Features;

public class SelectedThingFeature : Feature<SelectedThingState>
{
    public override string GetName()
    {
        return nameof(SelectedThingFeature);
    }

    protected override SelectedThingState GetInitialState()
    {
        return new SelectedThingState
        (
            FetchStatus: FetchingStatus.NotStarted,
            Error: null,
            Thing: null
        );
    }
}
