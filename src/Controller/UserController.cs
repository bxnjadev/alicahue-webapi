using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;
using ucn_user_review_backend_v3.Util;

namespace ucn_user_review_backend_v3.Controller;

[ApiController]
[Route("api/[controller]")]
public class UserController(
    IBaseRepository<User> repository,
    IObjectMapper<User, UserView> mapper,
    IObjectMapper<User, UserPreview> userPreviewMapper) : MainControllerBase<User,
    UserView>(repository, mapper)
{
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

        Collections.AddIf(searchedCareer != "",
            queries,
            preview => preview.Career == searchedCareer);

        Collections.AddIf(searchedName != "",
            queries,
            preview => preview.Name.ToLower().Contains(searchedName));

        Collections.AddIf(   universityType != "",
            queries,
            preview => preview.UniversityType == universityType);

        return Ok(await repository.SelectSearchWithPage(u => userPreviewMapper.Map(u),
            page,
            queries.ToArray()));
    }
}