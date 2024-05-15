using Project.Entities.Interfaces;
using System.Linq.Expressions;

namespace Project.Bll.ManagerServices.Abstracts
{
    public interface IManager<T> where T : class, IEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetActives();
        IQueryable<T> GetModifieds();
        IQueryable<T> GetPassives();


        string Add(T item);
        Task AddAsync(T item);
        void AddRange(List<T> list);
        Task AddRangeAsync(List<T> list);
        Task Update(T item);
        Task UpdateRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Destroy(T item);
        void DestroyRange(List<T> list);

        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

        Task<T> FindAsync(int id);
    }
}
