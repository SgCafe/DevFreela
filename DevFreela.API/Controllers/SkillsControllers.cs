using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

    [ApiController]
    [Route("api/skills")]
public class SkillsControllers : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult Post()
    {
        return Ok();
    }
}