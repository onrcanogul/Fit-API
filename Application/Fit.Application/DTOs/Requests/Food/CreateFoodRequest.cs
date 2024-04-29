using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Requests.Food
{
    public class CreateFoodRequest
    {
        public float Fat { get; set; }
        public float Protein { get; set; }
        public float Carbohydrate { get; set; }
        public string Name { get; set; }
        public int Calorie { get; set; }
    }
}
