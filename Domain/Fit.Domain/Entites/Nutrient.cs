using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fit.Domain.Entites.Base;

namespace Fit.Domain.Entites
{
    public class Nutrient : BaseEntity
    {
        public float Fat { get; set; }
        public float Carbohydrate { get; set; }
        public float Protein { get; set; }
        public string Name { get; set; }
        public int Calorie { get; set; }
        public float Measure { get; set; }
        public ICollection<Category>? Categories { get; set; }
        public ICollection<BasketCalorie>? BasketCalories { get; set; }
    }
}
