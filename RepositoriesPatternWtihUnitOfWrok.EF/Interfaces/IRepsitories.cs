using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoriesPatternWtihUnitOfWrok.EF.Interfaces
{
    public interface IRepsitories<T> where T : class
    {
        IEnumerable<T> GetRelatedItems(Expression<Func<T , bool>> match , string[] includes = null! );
        T GetById(Expression<Func<T , bool>> macth  = null, string[] includes = null);
        Task<T> GetByIdAsync(int id , Expression<Func<T , bool>>  match);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T Update(T entity);
        Task<T> UpdateAsync(T entity);
        T Delete(T entity);
        Task<T> DeleteAsync(T entity);
        T Add(T entity);
        Task<T> AddAsync(T entity);
        IEnumerable<T> AddRange(List<T> entityes);
        Task<IEnumerable<T>> AddRangeAsync(List<T> entityes);
    }
}
