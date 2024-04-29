using Fit.Application.Repositories.BasketItem;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.BasketItem
{
    public class BasketItemWriteRepository : WriteRepository<Domain.Entites.BasketItem>, IBasketItemWriteRepository
    {
        public BasketItemWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
