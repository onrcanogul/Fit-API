using Fit.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Domain.Entites
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Nutrient>? Nutrients{ get; set; }

    }
}
