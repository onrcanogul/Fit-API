using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Food
{
    public class UpdateNutrientDto
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbohydrate { get; set; }
        public int Calorie { get; set; }
    }
}
