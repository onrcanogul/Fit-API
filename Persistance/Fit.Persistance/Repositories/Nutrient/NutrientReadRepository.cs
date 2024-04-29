using Fit.Application.Repositories;
using Fit.Application.Repositories.Food;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.Food
{
    public class NutrientReadRepository : ReadRepository<Domain.Entites.Nutrient>, INutrientReadRepository
    {
        public NutrientReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
