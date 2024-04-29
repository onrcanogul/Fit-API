using Fit.Application.Repositories;
using Fit.Application.Repositories.Category;
using Fit.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<Domain.Entites.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
