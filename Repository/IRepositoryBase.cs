using System.Linq.Expressions;

namespace BookStoreAPI.Repository;

public interface IRepositoryBase<T>
{
    IQueryable<T> FindAll(bool trackChanges);
    IQueryable<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges);
    IQueryable<T> GetByTitle(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    bool Save();
}