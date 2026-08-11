using System.Linq.Expressions;

namespace ucn_user_review_backend_v3.Base;

public interface IBaseRepository<O>
{

    /**
     * Store a new entity in the repository
     * And retrieve the entity
     */
    O Store(O entity);
    
    /**
     * Delete a entity from this entity
     */
    
    O Delete(O entity);
    
    /**
     * Find entity from id id
     * this entity can be null
     */
    
    O? FindById(int id);

    /**
     * Find id async from id
     * this entity can be null
     */
    
    Task<O?> FindByIdAsync(int id);

    /**
     * Get all entities async 
     */
    
    Task<List<O>> AllAsync();

    Task<List<O>> AllWithIncludesAsync(int page, Expression<Func<O, bool>>? where = null, 
     params Expression<Func<O, object>>[] includes);
    
    /**
     * 
     * Store a new entity in the repository way async 
     */
    
    Task<O> StoreAsync(O entity);
    
    /**
     * Search a set entity from a conditions 
     */
    
    Task<List<O>> SearchAll(params Expression<Func<O, bool>>[] predicate);
    
    /**
     * Search a set entity from a page 
     */
    
    Task<List<O>> SearchWithPage(int page, params Expression<Func<O, bool>>[] predicate);

    /**
     *  Select a set entities from a page
     */
    
    Task<List<R>> SelectWithPage<R>(Expression<Func<O, R>> selector,
        int page);
    
    /**
    *  Select a set entities from a page with conditions
    */
    
    Task<List<R>> SelectSearchWithPage<R>(Expression<Func<O, R>> selector,
        int page, params Expression<Func<R, bool>>[] predicate);

}