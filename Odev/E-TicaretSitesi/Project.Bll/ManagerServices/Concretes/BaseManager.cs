using Project.Bll.ManagerServices.Abstracts;
using Project.Dal.Repositories.Abstracts;
using Project.Entities.Interfaces;
using System.Linq.Expressions;

namespace Project.Bll.ManagerServices.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class, IEntity
    {
        protected IRepository<T> _repository;
        public BaseManager(IRepository<T> repository)
        {
            _repository = repository;
        }

        public string Add(T item)
        {
            if (item.CreatedDate != null)
            {
                _repository.Add(item);
                return "Ekleme başarılı";
            }
            return "Ekleme başarısız";
        }

        public async Task AddAsync(T item)
        {
            await _repository.AddAsync(item);
        }

        public void AddRange(List<T> list)
        {
            _repository.AddRange(list);
        }

        public async Task AddRangeAsync(List<T> list)
        {
            await _repository.AddRangeAsync(list);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _repository.AnyAsync(exp);
        }

        public void Delete(T item)
        {
            _repository.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            _repository.DeleteRange(list);
        }

        public void Destroy(T item)
        {
            _repository.Destroy(item);
        }

        public void DestroyRange(List<T> list)
        {
            _repository.DestroyRange(list);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _repository.FirstOrDefaultAsync(exp);
        }

        public IQueryable<T> GetActives()
        {
            return _repository.GetActives();
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<T> GetModifieds()
        {
            return _repository.GetModifieds();
        }

        public IQueryable<T> GetPassives()
        {
            return _repository.GetPassives();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _repository.Select(exp);
        }

        public async Task Update(T item)
        {
            await _repository.Update(item);
        }

        public async Task UpdateRange(List<T> list)
        {
            await _repository.UpdateRange(list);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }
    }
}
