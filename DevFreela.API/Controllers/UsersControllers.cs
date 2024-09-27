using DevFreela.Application.Models;
using DevFreela.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersControllers : ControllerBase
{
    private readonly IUserService _service;

    public UsersControllers(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAllUsers(string search = "")
    {
        var result = _service.GetAllUsers(search);

        if (result is null)
        {
            return BadRequest(result.Data);
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var result = _service.GetById(id);

        if (result is null)
        {
            return BadRequest(result.Data);
        }

        return Ok(result);
    }

    // POST api/users
    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        var result = _service.Post(model);

        return NoContent();
    }

    [HttpPost("{id}/skills")]
    public IActionResult PostSkills(int id, UserSkillsInputModel model)
    {
        var result = _service.PostSkills(id, model);

        return NoContent();
    }

    [HttpPut("{id}/profile-picture")]
    public IActionResult PostProfilePicture(IFormFile file)
    {
        var description = $"File: {file.FileName}, Size: {file.Length}";

        //Processar Imagem

        return Ok(description);
    }
}