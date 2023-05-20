using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Features;

public class SimpleThingsFeature : Feature<SimpleThingsState>
{
    public override string GetName()
    {
        return nameof(SimpleThingsFeature);
    }

    protected override SimpleThingsState GetInitialState()
    {
        return new SimpleThingsState
        (
            FetchStatus: FetchingStatus.NotStarted,
            FetchError: null,
            Things: Array.Empty<ThingOverview>()
        );
    }
}
