using Fit.Application.Repositories;
using Fit.Application.Repositories.Drink;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.Drink
{
    public class DrinkReadRepository : ReadRepository<Domain.Entites.Drink>, IDrinkReadRepository
    {
        public DrinkReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
