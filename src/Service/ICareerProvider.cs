namespace ucn_user_review_backend_v3.Service;

public interface ICareerProvider
{

    List<string> All();

    bool Exists(string name);

}