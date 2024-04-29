using Fit.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Fit.Domain.Entites.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public int Age { get; set; }
        public float? Weight { get; set; }
        public float? Height { get; set; }
        public float? FatRate  { get; set; }
        public Gender Gender { get; set; }
        public float? BMR { get; set; }
        public string? Activity { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public BasketCalorie? BasketCalorie { get; set; }
        public Guid? BasketCalorieId { get; set; }
    }
}
