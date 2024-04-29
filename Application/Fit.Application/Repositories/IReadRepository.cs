using Fit.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method);
        IQueryable<T> GetWhere(Expression<Func<T,bool>> method);
        bool Any(Expression<Func<T, bool>> method); 
        
    }
}
