using Fit.Application.Repositories.BasketItem;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.BasketItem
{
    public class BasketItemReadRepository : ReadRepository<Domain.Entites.BasketItem>, IBasketItemReadRepository
    {
        public BasketItemReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
