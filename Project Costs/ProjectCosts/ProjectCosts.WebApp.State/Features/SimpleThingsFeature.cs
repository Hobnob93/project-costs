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
            FetchStatus: FetchingStatus.Loaded,
            Things: new []
            {
                new ThingOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "New Patio",
                    Cost = new Cost
                    {
                        Value = 1469.42m
                    },
                    Type = ThingType.Diy,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(50)),
                    Image = "https://nustone.co.uk/wp-content/uploads/2017/03/Raj-Green-Riven-Patio-Kit-67.jpg"
                },
                new ThingOverview
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
                    Type = ThingType.Holiday,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(150)),
                    Image = "https://www.singaporeair.com/saar5/images/navigation/flying-withus/our-fleet/boeing-787-10.jpg"
                },
                new ThingOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "LAN i70",
                    Cost = new Cost
                    {
                        Value = 515.00m
                    },
                    Type = ThingType.Event,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                    Image = "https://c.ststat.net/content/sites/insomnia/images/logo.png"
                },
                new ThingOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Amber's Birthday",
                    Cost = new Cost
                    {
                        Value = 100.00m
                    },
                    Type = ThingType.Birthday,
                    StartDate = new DateOnly(2023, 06, 20),
                    Image = "https://scontent.fbrs4-1.fna.fbcdn.net/v/t1.6435-9/175642927_10222843332485756_7995688513197375790_n.jpg?_nc_cat=108&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=zhjSpAijs40AX_xgs9i&_nc_ht=scontent.fbrs4-1.fna&oh=00_AfA2PvqaX3OOk1fzAY1DUJGReEfLfXKXa2OkhoKH0gdSnw&oe=646B8635"
                },
                new ThingOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Christmas 2023",
                    Cost = new Cost
                    {
                        Value = 400.00m
                    },
                    Type = ThingType.Christmas,
                    StartDate = new DateOnly(2023, 12, 25),
                    Image = "https://assets.editorial.aetnd.com/uploads/2009/10/christmas-gettyimages-184652817.jpg"
                },
                new ThingOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Some Random Thing",
                    Cost = new Cost
                    {
                        Value = 150.00m
                    },
                    Type = ThingType.Other,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(272))
                },
                new ThingOverview
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Some Other Random Thing",
                    Cost = new Cost
                    {
                        Value = 1500.00m
                    },
                    Type = ThingType.None,
                    StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(365))
                }
            }
        );
    }
}
