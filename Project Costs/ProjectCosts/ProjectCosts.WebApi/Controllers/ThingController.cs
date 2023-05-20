using Microsoft.AspNetCore.Mvc;
using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using System.Net.Mime;

namespace ProjectCosts.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ThingController : ControllerBase
{ 
    private readonly ILogger<ThingController> _logger;

    public ThingController(ILogger<ThingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetSimpleThings")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ThingOverview>))]
    public IActionResult GetSimpleThings()
    {
        return Ok(SimpleThings.ToList());
    }

    [HttpGet("{id}", Name = "GetSimpleThing")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThingOverview))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSimpleThing(string id)
    {
        var thing = SimpleThings.FirstOrDefault(t => t.Id == id);
        if (thing == null)
            return NotFound();

        return Ok(thing);
    }

    [HttpPost(Name = "CreateSimpleThing")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ThingOverview))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CreateSimpleThing(CreateThingData createThing)
    {
        if (createThing == null)
            return BadRequest();

        var newThing = new ThingOverview
        {
            Id = Guid.NewGuid().ToString(),
            Name = createThing.Name,
            Cost = new Cost
            {
                Value = 0
            },
            StartDate = createThing.StartDate,
            Image = createThing.Image,
            Type = createThing.Type
        };

        SimpleThings.Add(newThing);
        return CreatedAtAction(nameof(GetSimpleThing), new { id = newThing.Id }, newThing);
    }

    [HttpPut(Name = "UpdateSimpleThing")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThingOverview))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateSimpleThing(UpdateThingData updateThing)
    {
        if (updateThing == null)
            return BadRequest();

        var existingThing = SimpleThings.FirstOrDefault(t => t.Id == updateThing.Id);
        if (existingThing == null)
            return NotFound();

        existingThing.Name = updateThing.Name;
        existingThing.StartDate = updateThing.StartDate;
        existingThing.Image = updateThing.Image;
        existingThing.Type = updateThing.Type;

        return Ok(existingThing);
    }

    [HttpDelete("{id}", Name = "DeleteSimpleThing")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteSimpleThing(string id)
    {
        var thing = SimpleThings.FirstOrDefault(t => t.Id == id);
        if (thing == null)
            return NotFound();

        SimpleThings.Remove(thing);
        return NoContent();
    }

    private List<ThingOverview> SimpleThings = new()
    {
        new ThingOverview
        {
            Id = "03B39058-07DE-4D3F-8C2C-A8EBD5FF9D2A",
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
            Id = "C979EA94-8576-450A-B40A-8A4AC525F8DF",
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
            Id = "6EDDAD2C-BC13-4F11-A040-691FD0F84326",
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
            Id = "0321535A-7025-4F1B-91D7-95CBBF23793D",
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
            Id = "75825BC1-234C-410D-A2E5-CB6AF5FE2863",
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
            Id = "820AA71E-02F7-4F0C-8A5E-67E838B88979",
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
            Id = "696603C4-5C84-4FFD-9B82-76628D546414",
            Name = "Some Other Random Thing",
            Cost = new Cost
            {
                Value = 1500.00m
            },
            Type = ThingType.None,
            StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(365))
        }
    };
}