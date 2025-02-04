using System.Linq.Expressions;

namespace ucn_user_review_backend_v3.Service;

public interface IBaseService<O>
{

    O Store(O entity);
    
    O Delete(O entity);
    
    O? FindById(int id);

    Task<O?> FindByIdAsync(int id);

    Task<List<O>> AllAsync();

    Task<O> StoreAsync(O entity);
    
    Task<List<O>> SearchAll(params Expression<Func<O, bool>>[] predicate);
    
    Task<List<O>> SearchWithPage(int page, params Expression<Func<O, bool>>[] predicate);

    Task<List<R>> SelectWithPage<R>(Expression<Func<O, R>> selector,
        int page);
    
    Task<List<R>> SelectSearchWithPage<R>(Expression<Func<O, R>> selector,
        int page, params Expression<Func<R, bool>>[] predicate);

}