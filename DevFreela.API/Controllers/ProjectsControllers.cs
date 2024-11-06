using DevFreela.Application.Commands.ProjectCommands.CompleteProject;
using DevFreela.Application.Commands.ProjectCommands.DeleteProject;
using DevFreela.Application.Commands.ProjectCommands.InsertComment;
using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Application.Commands.ProjectCommands.StartProject;
using DevFreela.Application.Commands.ProjectCommands.UpdateProject;
using DevFreela.Application.Querys.ProjectQuerys.GetAllProjects;
using DevFreela.Application.Querys.ProjectQuerys.GetProjectById;
using DevFreela.Application.Services.Project;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsControllers : ControllerBase
{
    private readonly IProjectService _service;
    private readonly IMediator _mediatoR;

    public ProjectsControllers(IProjectService service, IMediator mediatoR)
    {
        _service = service;
        _mediatoR = mediatoR;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers(string search = "", int page = 0, int size = 3)
    {
        var query = new GetAllProjectsQuery();
        var result = await _mediatoR.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediatoR.Send(new GetProjectByIdQuery(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertProjectCommand command)
    {
        var result = await _mediatoR.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(UpdateProjectCommand command)
    {
        var result = await _mediatoR.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediatoR.Send(new DeleteProjectCommand(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }

    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id)
    {
        var result = await _mediatoR.Send(new StartProjectCommand(id));

        return NoContent();
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        var result = await _mediatoR.Send(new CompleteProjectCommand(id));
        return NoContent();
    }

    [HttpPost("{id}/comments")]
    public async Task<IActionResult> PostComments(InsertCommentCommand command)
    {
        var result = await _mediatoR.Send(command);

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return NoContent();
    }
}