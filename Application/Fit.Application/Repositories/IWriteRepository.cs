using Fit.Domain.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Application.Repositories
{
    public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
    {
       Task AddAsync(T entity);
       Task AddRangeAsync(List<T> entites);
       void Update(T entity);
       Task RemoveAsync(string id);
       void RemoveRange(List<T> entites);
        Task<int> SaveAsync();

    }
}
