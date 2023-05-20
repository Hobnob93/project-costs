using Microsoft.AspNetCore.Mvc;
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
        return Ok(TmpStaticThings.SimpleThings.ToList());
    }

    [HttpGet("{id}", Name = "GetSimpleThing")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ThingOverview))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetSimpleThing(string id)
    {
        var thing = TmpStaticThings.SimpleThings.FirstOrDefault(t => t.Id == id);
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

        TmpStaticThings.SimpleThings.Add(newThing);
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

        var existingThing = TmpStaticThings.SimpleThings.FirstOrDefault(t => t.Id == updateThing.Id);
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
        var thing = TmpStaticThings.SimpleThings.FirstOrDefault(t => t.Id == id);
        if (thing == null)
            return NotFound();

        TmpStaticThings.SimpleThings.Remove(thing);
        return NoContent();
    }
}