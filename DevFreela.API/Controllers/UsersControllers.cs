using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

    [ApiController]
    [Route("api/users")]
public class UsersControllers : ControllerBase
{
    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        return Ok();
    }

    [HttpPost("{id}/skills")]
    public IActionResult PostSkills(UserSkillsInputModel model)
    {
        return NoContent();
    }
    
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

    [HttpPut("{id}/profile-picture")]
    public IActionResult PostProfilePicture(IFormFile file)
    {
        var description = $"File: {file.FileName}, Size: {file.Length}";
        
        //Processar Imagem
        
        return Ok(description);
    }
}