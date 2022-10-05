using Microsoft.EntityFrameworkCore;
using RepositoriesPatternWtihUnitOfWrok.EF.Interfaces;
using System.Linq.Expressions;

namespace RepositoriesPatternWithUnitOfWork.Core
{
    public class ClsRepositories<T> : IRepsitories<T> where T : class
    {
        private readonly ApplicationDbContext _Context;
        public IEnumerable<T> GetRelatedItems(Expression<Func<T, bool>> match, string[] includes = null!)
        {
            IQueryable<T> query = _Context.Set<T>();
            if(includes != null)
                foreach(string include in includes)
                    query = query.Include(include);
            return query.Where(match).ToList();
        }
        public ClsRepositories(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        public T Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            _Context.SaveChanges();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _Context.Set<T>().AddAsync(entity);
            _Context.SaveChanges();
            return entity;
        }
        
        public IEnumerable<T> AddRange(List<T> entityes)
        {
            _Context.Set<T>().AddRange(entityes);
            _Context.SaveChanges();
            return entityes;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(List<T> entityes)
        {
            await _Context.Set<T>().AddRangeAsync(entityes);
            _Context.SaveChanges();
            return entityes;
        }

        public T Delete(T entity)
        {
            _Context.Remove(entity);
            _Context.SaveChanges();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _Context.Remove(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public T GetById(Expression<Func<T, bool>> macth = null, string[] includes = null)
        {
            IQueryable<T> query = _Context.Set<T>();
            if(includes is not null)
                foreach(string include in includes)
                    query = query.Include(include);
            return query.SingleOrDefault(macth);
        }

        public Task<T> GetByIdAsync(int id, Expression<Func<T, bool>> match)
        {
            return _Context.Set<T>().SingleOrDefaultAsync(match);
        }

        public T Update(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            _Context.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return entity;
        }
    }
}
