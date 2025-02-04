using Microsoft.EntityFrameworkCore;

namespace ucn_user_review_backend_v3.Data;

public interface IDataSourceRepository
{
    
    void Register<T>(DbSet<T> dbSet) where T : class;

    DbSet<T> Get<T>() where T : class;

}