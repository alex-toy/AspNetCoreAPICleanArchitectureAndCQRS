using Microsoft.AspNetCore.Mvc;

namespace Social.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[ApiController]
public class PostController : Controller
{
    [HttpGet]
    [Route(ApiRoutes.Posts.IdRoute)]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
}
