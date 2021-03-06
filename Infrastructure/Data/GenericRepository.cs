using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{ 
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await AppySpecification(spec).ToListAsync();

        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
           return await AppySpecification(spec).FirstOrDefaultAsync();

        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await AppySpecification(spec).CountAsync();
        }

        private IQueryable<T> AppySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQueryable(_context.Set<T>().AsQueryable(), spec);
        }

        
    }
}