using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Data;
using ucn_user_review_backend_v3.Model;

namespace ucn_user_review_backend_v3.Service;

public class CareerProviderRepository(ApplicationDbContext applicationDbContext) : ICareerProvider
{

    private readonly DbSet<User> _users =
        applicationDbContext.Users;
    
    public async Task<List<string>> All()
    {
        return await _users.Select(
                u => u.CareerName
            ).Distinct()
            .Where(career => career != "")
            .ToListAsync();
    }

    public bool Exists(string name)
    {
        throw new NotImplementedException();
    }
    
}