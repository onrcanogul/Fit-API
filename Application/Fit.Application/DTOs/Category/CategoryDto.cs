
using Fit.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.DTOs.Category
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public ICollection<Nutrient> Nutrients{ get; set; }
    }
}
