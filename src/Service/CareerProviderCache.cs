namespace ucn_user_review_backend_v3.Service;

public class CareerProviderCache(List<string> careers) : ICareerProvider
{
    
    public List<string> All()
    {
        return careers;
    }

    public bool Exists(string name)
    {
        return careers.Contains(name);
    }
}