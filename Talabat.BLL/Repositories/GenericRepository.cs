
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.API.Specifications;
using Talabat.BLL.Interfaces;
using Talabat.DAL;
using Talabat.DAL.Entities;

namespace Talabat.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            _context = context;
        }

        //public void Add(T entity)
        //=> _context.Set<T>().Add(entity);

        public async Task Add(T entity)
        =>await _context.Set<T>().AddAsync(entity);
        public void Delete(T entity)
         => _context.Set<T>().Remove(entity);
        public void Update(T entity)
       // => _context.Entry(entity).State = EntityState.Modified;
        => _context.Set<T>().Update(entity);

        public async Task<IReadOnlyList<T>> GetAllAsync()
       => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
        
          =>await ApplySpecifications(spec).ToListAsync();
        

        public async Task<T> GetAsync(int id)
        => await _context.Set<T>().FindAsync(id);

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        => await ApplySpecifications(spec).CountAsync();

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
        => await ApplySpecifications(spec).FirstOrDefaultAsync();


        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>(), spec);
        }
    }
}
