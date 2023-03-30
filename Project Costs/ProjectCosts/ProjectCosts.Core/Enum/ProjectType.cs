using System.ComponentModel.DataAnnotations;

namespace ProjectCosts.Core.Enum;

public enum ProjectType
{
    [Display(Name = "Unknown")]
    None,
    [Display(Name = "DIY")]
    Diy,
    [Display(Name = "Event")]
    Event,
    [Display(Name = "Holiday")]
    Holiday,
    [Display(Name = "Other")]
    Other
}
