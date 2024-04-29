using Fit.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Basket
{
    public class BasketItemDto
    {
        public object BasketItems { get; set; }
        //public float Fat { get; set; }
        //public string Id { get; set; }
        //public float Carbohydrate { get; set; }
        //public float Protein { get; set; }
        //public string Name { get; set; }
        //public int Calorie { get; set; }
        //public float? Measure { get; set; }
        public float? TotalCalorie { get; set; }
        public float? TotalProtein { get; set; }
        public float? TotalFat { get; set; }
        public float? TotalCarbohydrate { get; set; }
    }
}
