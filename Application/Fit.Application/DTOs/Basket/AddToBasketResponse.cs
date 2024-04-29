using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Basket
{
    public class AddToBasketRequest
    {
        public string NutrientId { get; set; }
        public float Measure { get; set; }
    }
}
