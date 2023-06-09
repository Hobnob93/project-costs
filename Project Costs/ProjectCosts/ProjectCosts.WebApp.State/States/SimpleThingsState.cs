﻿using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;

namespace ProjectCosts.Web.Store.States;

public record SimpleThingsState
(
    FetchingStatus FetchStatus,
    string? FetchError,
    ThingOverview[] Things
) : BaseApiFetchState(FetchStatus, FetchError);
