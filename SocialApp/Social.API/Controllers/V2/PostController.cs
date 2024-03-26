using Microsoft.AspNetCore.Mvc;
using Social.Domain.Models;

namespace Social.API.Controllers.V2;

[ApiVersion("2.0")]
[Route("api/{version:apiVersion}/[controller]")]
[ApiController]
public class PostController : Controller
{
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok(new Post() { Id = id, Text = "hello universe" });
    }
}
