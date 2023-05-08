using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.Actions;

public record SetSimpleThingsAction(ThingOverview[] Things);
