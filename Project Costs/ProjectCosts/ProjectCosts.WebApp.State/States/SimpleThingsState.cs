﻿using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record SimpleThingsState(FetchingStatus FetchStatus, ThingOverview[] Things);
