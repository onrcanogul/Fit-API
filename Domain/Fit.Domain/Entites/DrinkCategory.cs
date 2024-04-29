using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fit.Domain.Entites.Base;

namespace Fit.Domain.Entites
{
    public class DrinkCategory : Category
    {
        public ICollection<Drink>? Drinks { get; set; }
    }
}
