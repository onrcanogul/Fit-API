using Fit.Domain.Entites.Base;
using Fit.Domain.Entites.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Domain.Entites
{
    public class BasketCalorie: BaseEntity
    {
        [ForeignKey("User")]
        public string? UserId { get; set; }

        public AppUser? User { get; set; }
        public ICollection<BasketItem>? BasketItems{ get; set; }
        
    }
}
