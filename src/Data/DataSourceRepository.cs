using Microsoft.EntityFrameworkCore;

namespace ucn_user_review_backend_v3.Data;

public class DataSourceRepository : IDataSourceRepository
{
    private readonly Dictionary<Type, object> _sources = [];

    public void Register<T>(DbSet<T> dbSet) where T : class
    {
        _sources[typeof(T)] = dbSet;
    }

    public DbSet<T> Get<T>() where T : class
    {
        return (DbSet<T>) _sources[typeof(T)];
    }
    
}