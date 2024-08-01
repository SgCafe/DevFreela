using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

    [ApiController]
    [Route("api/users")]
public class UsersControllers : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllUsers()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }
}