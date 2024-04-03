using Microsoft.AspNetCore.Mvc;

namespace Social.API.Controllers.V1;

[ApiVersion("1.0")]
[Route("api/{version:apiVersion}/[controller]")]
[ApiController]
public class PostController : Controller
{
    //[MapToApiVersion("2.0")]
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
}
