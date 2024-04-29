using Fit.Application.Repositories;
using Fit.Domain.Entites.Base;
using Fit.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fit.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity) => await _context.AddAsync(entity);

        public async Task AddRangeAsync(List<T> entites) => await _context.AddRangeAsync(entites);

        public async Task RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(t => t.Id == Guid.Parse(id));
            _context.Remove(model);
        }

        public void RemoveRange(List<T> entites) => _context.RemoveRange(entites);
        
        public async Task<int> SaveAsync() =>  await _context.SaveChangesAsync();
        

        public void Update(T entity) => _context.Update(entity);
        
    }
}
