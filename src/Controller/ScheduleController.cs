using Microsoft.AspNetCore.Mvc;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Schedule;

namespace ucn_user_review_backend_v3.Controller;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController(ICourseManager courseManager,
    IObjectMapper<Model.Schedule, ScheduleView> mapper) : ControllerBase
{

    [HttpGet]
    [Route("/api/schedule/find/{id}")]
    public async Task<ActionResult<ScheduleView>> Find(int id)
    {
        var schedule = await courseManager.FindSchedule(id);
        if (schedule == null)
        {
            return NotFound("User not found");
        }
            
        return Ok(mapper.Map(schedule));
    }

    [HttpGet]
    [Route("/api/schedule/common-schedule")]
    public async Task<ActionResult<IDictionary<string, IList<string>>>> FindCommonSchedule(
            [FromBody] int[] ids
        )
    { 
        return Ok(await courseManager.MatchSchedule(
                ids.ToHashSet()
            ));
    }
    
}