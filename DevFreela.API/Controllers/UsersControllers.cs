using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

    [ApiController]
    [Route("api/users")]
public class UsersControllers : ControllerBase
{
    private readonly DevFreelaDbContext _context;

    public UsersControllers(DevFreelaDbContext context)
    {
        _context = context;
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
    
    [HttpPost]
    public IActionResult Post(CreateUserInputModel model)
    {
        var user = model.ToEntity();

        _context.Users.Add(user);
        _context.SaveChanges();
        
        return NoContent();
    }

    [HttpPost("{id}/skills")]
    public IActionResult PostSkills(UserSkillsInputModel model)
    {
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