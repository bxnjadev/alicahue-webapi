using Microsoft.AspNetCore.Mvc;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;

namespace ucn_user_review_backend_v3.Controller;

[ApiController]
[Route("api/[controller]")]
public class CourseController(
    IBaseService<Course> service,
    IObjectMapper<Course, CourseView> mapper,
    ICareerProvider careerProvider) : MainControllerBase<Course, CourseView>(service, mapper )
{
    
    [HttpGet]
    [Route("/api/courses/all")]
    public async Task<ActionResult<List<CourseView>>> All()
    {
        return await AllAsync();
    }

    [HttpGet]
    [Route("/api/courses/find/{id}")]
    public async Task<ActionResult<CourseView>> Find(int id)
    {
        return await FindByIdAsync(id);
    }

    [HttpGet]
    [Route("/api/courses/all-career")]
    public async Task<ActionResult<List<string>>> AllCareer()
    {
        return Ok(await careerProvider.All());
    }
    
}