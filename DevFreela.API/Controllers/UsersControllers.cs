using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult GetAllUsers(string search = "")
    {
        var user = _context.Users
            .Where(u => !u.IsDeleted)
            .ToList();

        var model = user.Select(UsersViewmodel.FromEntity).ToList();
        
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users
            .Include(u => u.Skills)
                .ThenInclude(u => u.Skill)
            .SingleOrDefault(u => u.Id == id);

        if (user is null)
        {
            return NotFound();
        }

        var model = UsersViewmodel.FromEntity(user);
        
        return Ok(model);
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
    public IActionResult PostSkills(int id, UserSkillsInputModel model)
    {
        //Vai criar um new UserSK
        var userSkills = model.SkillsIds
            .Select(s => new UserSkill(id, s))
            .ToList();
        
        _context.UserSkills.AddRange(userSkills);
        _context.SaveChanges();
        
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