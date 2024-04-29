using Fit.Application.Repositories.Category;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.Category
{
    public class CategoryReadRepository : ReadRepository<Domain.Entites.Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
