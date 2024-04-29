using Fit.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Domain.Entites
{
    public class BasketItem: BaseEntity
    {
        public Nutrient? Nutrient { get; set; }
        public Guid? NutrientId { get; set; }
        public Guid BasketCalorieId { get; set; }
        public BasketCalorie BasketCalorie { get; set; }
        public float? Measure { get; set; }
    }
}
