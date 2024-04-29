using Fit.Application.Repositories.BasketCalorie;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.BasketCalories
{
    public class BasketCaloriesWriteRepository : WriteRepository<Domain.Entites.BasketCalorie>, IBasketCalorieWriteRepository
    {
        public BasketCaloriesWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
