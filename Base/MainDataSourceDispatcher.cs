using ucn_user_review_backend_v3.Data;

namespace ucn_user_review_backend_v3.Base;

public class MainDataSourceDispatcher(ApplicationDbContext 
    applicationDbContext) : IDataSourceDispatcher
{
    
    public void Dispatch()
    {
        applicationDbContext.SaveChanges();
    }

    public async void DispatchAsync()
    {
       await applicationDbContext.SaveChangesAsync();
    }
    
}