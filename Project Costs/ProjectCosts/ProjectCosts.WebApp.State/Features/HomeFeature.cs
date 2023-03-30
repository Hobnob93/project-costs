using Fluxor;
using ProjectCosts.Core.Models;
using ProjectCosts.Web.Store.States;

namespace ProjectCosts.Web.Store.Features;

public class HomeFeature : Feature<HomeState>
{
    public override string GetName()
    {
        return nameof(HomeFeature);
    }

    protected override HomeState GetInitialState()
    {
        return new HomeState
        (
            new []
            {
                new ProjectOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "House Project",
                    Cost = new Cost
                    {
                        Value = 1469.42m
                    },
                    Type = Core.Enum.ProjectType.Diy,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(50)),
                    Image = "https://rocketleague.media.zestyio.com/seasonylogostime.jpg?width=1440&optimize=high"
                },
                new ProjectOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "New Zealand Holiday",
                    Cost = new Cost
                    {
                        Estimate = new Estimate
                        {
                            LowerEstimate = 489.00m,
                            UpperEstimate = 644.00m
                        }
                    },
                    Type = Core.Enum.ProjectType.Holiday,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(150)),
                    Image = "https://www.singaporeair.com/saar5/images/navigation/flying-withus/our-fleet/boeing-787-10.jpg"
                },
                new ProjectOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "LAN i70",
                    Cost = new Cost
                    {
                        Value = 515.00m
                    },
                    Type = Core.Enum.ProjectType.Event,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                    Image = "https://c.ststat.net/content/sites/insomnia/images/logo.png"
                },
                new ProjectOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Some Random Thing",
                    Cost = new Cost
                    {
                        Value = 150.00m
                    },
                    Type = Core.Enum.ProjectType.Other,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(272))
                }
            }
        );
    }
}
