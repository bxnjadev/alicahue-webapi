using Microsoft.AspNetCore.Mvc;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Service;

namespace ucn_user_review_backend_v3.Base;

public class MainControllerBase<O, R>(IBaseRepository<O> repository,
    IObjectMapper<O, R> mapper) : ControllerBase where O : class
{

    [NonAction]
    protected async Task<ActionResult<R>> FindByIdAsync(int id)
    {
        var o = await repository.FindByIdAsync(id);
        if (o == null)
        {
            return NotFound("Element not found");
        }

        var r = mapper.Map(o);
        return Ok(r);
    }

    [NonAction]
    protected async Task<ActionResult<List<R>>> AllAsync()
    {

        var elements = await repository.AllAsync();
        var elementsMapped = mapper.Map(elements);
        
        return Ok(
                elementsMapped
            );
    }

    [NonAction]
    protected async Task<ActionResult<R>> Create(O o)
    {
        o = await repository.StoreAsync(o);
        var r = mapper.Map(o);
        return r;
    }
     
}