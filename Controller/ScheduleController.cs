using Microsoft.AspNetCore.Mvc;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Schedule;

namespace ucn_user_review_backend_v3.Controller;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController(IScheduleHandler scheduleHandler,
    IObjectMapper<Model.Schedule, ScheduleView> mapper) : ControllerBase
{

    [HttpGet]
    [Route("/api/schedule/find/{id}")]
    public async Task<ActionResult<ScheduleView>> Find(int id)
    {
        return  Ok(
                mapper.Map(await scheduleHandler.GetSchedule(id))
            );
    }
    
}