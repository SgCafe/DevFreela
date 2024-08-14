using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

    [ApiController]
    [Route("api/projects")]
public class ProjectsControllers : ControllerBase
{
    private readonly DevFreelaDbContext _context;
    
    public ProjectsControllers(DevFreelaDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Get(string search = "")
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        throw new Exception(); 
        return Ok();
    }

    [HttpPost]
    public IActionResult Post(CreateProjectInputModel model,int id)
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