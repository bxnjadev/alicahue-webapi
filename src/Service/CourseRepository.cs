using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Data;
using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Service;

public class CourseRepository(ApplicationDbContext applicationDbContext, IDataSourceDispatcher dispatcher) : BaseRepository<Course>(applicationDbContext, dispatcher)
{
    
    public override async Task<List<Course>> SearchAll(params Expression<Func<Course, bool>>[] predicate)
    {

        var set = DbSet.Include(c => c.Professors)
            .Include(c => c.Blocks);
        return await ApplyManyWhere(set, predicate)
            .ToListAsync();
        
    }
    
    public override async Task<Course?> FindByIdAsync(int id)
    {
        return await DbSet.Include(c => c.Professors).
            Include(c => c.Blocks)
            .Where(c => c.Id == id)
            .FirstAsync();
    }
    
}