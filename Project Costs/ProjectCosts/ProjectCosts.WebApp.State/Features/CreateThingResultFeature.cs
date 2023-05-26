using Fluxor;
using ProjectCosts.Core.Enum;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Features;

public class CreateThingResultFeature : Feature<CreateThingResultState>
{
    public override string GetName() => nameof(CreateThingResultFeature);

    protected override CreateThingResultState GetInitialState()
    {
        return new CreateThingResultState(
            CreatedThing: null,
            CreateStatus: UpdatingStatus.NotStarted,
            CreateError: null
        );
    }
}
