using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Data;

namespace ucn_user_review_backend_v3.Service;

public class BaseRepository<O>(
    ApplicationDbContext applicationDbContext,
    IDataSourceDispatcher dispatcher) :
    IBaseRepository<O> where O : class
{

    protected readonly DbSet<O> DbSet = applicationDbContext
        .Set<O>();
    
    private const int CountElements = 10;
    
    public virtual O Store(O entity)
    {
        DbSet.Add(entity);
        dispatcher.Dispatch();
        return entity;
    }

    public virtual O Delete(O entity)
    {
        DbSet.Remove(entity);
        dispatcher.Dispatch();
        return entity;
    }

    public virtual O? FindById(int id)
    {
        return DbSet.Find(id);
    }

    public virtual async Task<O?> FindByIdAsync(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<List<O>> AllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<O> StoreAsync(O entity)
    {
        await DbSet.AddAsync(entity);
        dispatcher.DispatchAsync();
        return entity;
    }
    
    public virtual async Task<List<O>> SearchAll(params Expression<Func<O, bool>>[] predicate)
    {
        return await ApplyManyWhere(DbSet, predicate)
            .ToListAsync();
    }

    public virtual async Task<List<O>> SearchWithPage(int page, 
        params Expression<Func<O, bool>>[] predicate)
    {
        var firstPosition = (page - 1) * CountElements;
        return await ApplyManyWhere(DbSet, predicate)
            .Skip(firstPosition)
            .Take(CountElements)
            .ToListAsync();
    }

    public virtual async Task<List<R>> SelectWithPage<R>(Expression<Func<O, R>> selector, int page)
    {
        var firstPosition = (page - 1) * CountElements;
        return await DbSet.Select(selector)
            .Skip(firstPosition)
            .Take(CountElements)
            .ToListAsync();
    }

    public async Task<List<R>> SelectSearchWithPage<R>(Expression<Func<O,R>> selector,
        int page,
        params Expression<Func<R, bool>>[] predicate)
    {
        var firstPosition = (page - 1) * CountElements;
        var selectedItems = DbSet.Select(selector);

        return await ApplyManyWhere(selectedItems, predicate)
            .Skip(firstPosition)
            .Take(CountElements)
            .ToListAsync();
    }

    protected IQueryable<E> ApplyManyWhere<E>(IQueryable<E> set,
        params Expression<Func<E, bool>>[] predicate)
    {
        
        foreach (var expression in predicate)
        {
            Console.WriteLine("MAKE WHERE");
            set = set.Where(expression);
        }

        return set;
    }
    
}