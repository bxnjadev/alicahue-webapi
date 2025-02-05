using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;

namespace ucn_user_review_backend_v3.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController(IBaseRepository<User> repository, IObjectMapper<User, UserView> mapper) : MainControllerBase<User,
    UserView>(repository, mapper)
{
    private const string StringEmpty = "";

    [HttpGet]
    [Route("/api/find/{id}")]
    public async Task<ActionResult<UserView>> Find(int id)
    {
        return await FindByIdAsync(id);
    }


    [HttpGet]
    [Route("/api/all")]
    public async Task<ActionResult<List<UserPreview>>> All([FromQuery] int page = 1,
        [FromQuery] string searchedName = "",
        [FromQuery] string searchedCareer = "",
        [FromQuery] string universityType = "")
    {
        
        var queries = new List<Expression<Func<UserPreview, bool>>>();
        
        if(searchedCareer != "")
        {
            queries.Add(preview => preview.Career == searchedCareer);
        }
        
        if (searchedName != "")
        {
            queries.Add(preview => preview.Name.ToLower().Contains(searchedName));
        }
        
        if (universityType != "")
        {
            queries.Add(preview => preview.UniversityType == universityType);
        }
        
        Console.WriteLine(queries.Count);
        return Ok(await repository.SelectSearchWithPage(u => new UserPreview
        {
            Id = u.Id,
            Name = u.Name,
            Career = u.CareerName,
            UniversityType = u.UniversityType
        }, page, queries.ToArray()));
    }
    
}