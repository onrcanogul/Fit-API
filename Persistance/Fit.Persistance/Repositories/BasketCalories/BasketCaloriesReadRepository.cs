using Fit.Application.Repositories.BasketCalorie;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.BasketCalories
{
    public class BasketCaloriesReadRepository : ReadRepository<Domain.Entites.BasketCalorie>, IBasketCalorieReadRepository
    {
        public BasketCaloriesReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
