using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Mapper.Types;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;

namespace ucn_user_review_backend_v3.Controller;

[ApiController]
[Route("api/[controller]")]
public class CourseController(
    IBaseRepository<Course> repository,
    IObjectMapper<Course, CourseView> mapper,
    ICareerProvider careerProvider) : MainControllerBase<Course, CourseView>(repository, mapper )
{
    
    private readonly CourseMapper mapper = 
        new CourseMapper(new ProfessorMapper(), new BlockMapper());
    
    [HttpGet]
    [Route("/api/courses/all")]
    public async Task<ActionResult<List<CourseView>>> All(
        [FromQuery] int page = 1,
        [FromQuery] string searchedCourseName = ""
        )
    {

        Expression<Func<Course, bool>>? where = null;
        if (searchedCourseName != "")
        {
            Console.WriteLine("Aplicando where");
            where = course => course.Name.ToLower().Contains(searchedCourseName);
        }
        
        var courses = await repository.AllWithIncludesAsync(page, where, course => course.Blocks, course => course.Professors);
        var coursesView = new List<CourseView>();
            
        foreach (var course in courses)
        {
            coursesView.Add(mapper.Map(course));     
        }
        
        return coursesView;
    }

    [HttpGet]
    [Route("/api/courses/find/{id}")]
    public async Task<ActionResult<CourseView>> Find(int id)
    {
        return await FindByIdAsync(id);
    }

    [HttpGet]
    [Route("/api/courses/all-career")]
    public ActionResult<List<string>> AllCareer()
    {
        return Ok( careerProvider.All());
    }
    
}