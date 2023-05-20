using ProjectCosts.Core.Enum;
using ProjectCosts.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjectCosts.Web.Components.ViewModel;

public class EditThingViewModel
{
    public string Id { get; set; } = string.Empty;

    [Required(ErrorMessage = "You have not provided a name for the 'thing'")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Please provide a date for when the 'thing' takes place")]
    public DateTime? StartDate { get; set; }

    public string? Image { get; set; }
    public ThingType Type { get; set; }
}
