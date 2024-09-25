using DevFreela.Application.Models;
using DevFreela.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsControllers : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsControllers(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult Get(string search = "", int page = 0, int size = 3)
    {
        var result = _service.GetAll();


        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public IActionResult Post(CreateProjectInputModel model)
    {
        var result = _service.Post(model);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateProjectInputModel model)
    {
        var result = _service.Put(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        var result = _service.Start(id);

        return NoContent();
    }

    [HttpPut("{id}/complete")]
    public IActionResult Complete(int id)
    {
        var result = _service.Complete(id);
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComments(int id, CreateProjectCommentInputModel model)
    {
        var result = _service.PostComments(id, model);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}