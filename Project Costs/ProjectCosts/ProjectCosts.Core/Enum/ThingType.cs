using System.ComponentModel.DataAnnotations;

namespace ProjectCosts.Core.Enum;

public enum ThingType
{
    [Display(Name = "Unknown")]
    None,
    [Display(Name = "DIY")]
    Diy,
    [Display(Name = "Event")]
    Event,
    [Display(Name = "Holiday")]
    Holiday,
    [Display(Name = "Birthday")]
    Birthday,
    [Display(Name = "Christmas")]
    Christmas,
    [Display(Name = "Other")]
    Other
}
