using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

    [ApiController]
    [Route("api/projects")]
public class ProjectsControllers : ControllerBase
{
    [HttpGet]
    public IActionResult Get(string search)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        return Ok();
    }

    [HttpPost("{id}")]
    public IActionResult Post(CreateProjectInputModel model, int id)
    {
        return CreatedAtAction(nameof(GetById), new {id = 1}, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateProjectInputModel model)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        return Ok();
    }

    [HttpPut("{id}/complete")]
    public IActionResult Complete(int id)
    {
        return Ok();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComments(int id, CreateProjectCommentInputModel model)
    {
        return Ok();
    }
}