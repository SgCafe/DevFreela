using DevFreela.Application.Commands.UserCommands.InsertSkills;
using DevFreela.Application.Commands.UserCommands.InsertUser;
using DevFreela.Application.Commands.UserCommands.LoginUser;
using DevFreela.Application.Querys.UserQuerys.GetAllUsers;
using DevFreela.Application.Querys.UserQuerys.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersControllers : ControllerBase
{
    private readonly IMediator _mediatoR;

    public UsersControllers(IMediator mediator)
    {
        _mediatoR = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        var result = await _mediatoR.Send(query);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediatoR.Send(new GetUserByIdQuery(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertUserCommand command)
    {
        var result = await _mediatoR.Send(command);

        return NoContent();
    }

    [HttpPost("{id}/skills")]
    public async Task<IActionResult> PostSkills(InsertSkillsCommand command)
    {
        var result = await _mediatoR.Send(command);

        return NoContent();
    }

    [HttpPut("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var result = await _mediatoR.Send(command);

        if (result is null)
        {
            return BadRequest(result?.Message);
        }

        return Ok(result.Data);
    }
}