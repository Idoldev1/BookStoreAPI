using System.Linq.Expressions;
using BookStoreAPI.DAL;
using BookStoreAPI.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected BookStoreDbContext context;

    public RepositoryBase(BookStoreDbContext context)
    {
        this.context = context;
    }

    public void Add(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        context.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ? context.Set<T>().AsNoTracking() : context.Set<T>();

    public IQueryable<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges) => !trackChanges ? context.Set<T>().Where(expression).AsNoTracking() : context.Set<T>().Where(expression);

    public IQueryable<T> GetByTitle(Expression<Func<T, bool>> expression)
    {
        return context.Set<T>().Where(expression).AsNoTracking();
    }

    public bool Save()
    {
        var saved = context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public void Update(T entity)
    {
        context.Set<T>().Update(entity);
    }

    
}