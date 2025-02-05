using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Data;
using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Service;

public class CareerProviderRepository(ApplicationDbContext applicationDbContext) : ICareerProvider
{

    private readonly DbSet<User> _users =
        applicationDbContext.Users;

    private ICareerProvider? _cache;
    
    public List<string> All()
    {
        if (_cache != null)
        {
            return _cache.All();
        }
        
        var careers =  _users.Select(
                u => u.CareerName
            ).Distinct()
            .Where(career => career != "")
            .ToList();
        _cache = new CareerProviderCache(careers);
        return careers;
    }

    public bool Exists(string name)
    {
        throw new NotImplementedException();
    }
    
}