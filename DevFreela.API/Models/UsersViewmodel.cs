using DevFreela.API.Entities;

namespace DevFreela.API.Models;

public class UsersViewmodel
{
    public UsersViewmodel(string fullName, string email, DateTime birthDate, List<string> skills)
    {
        FullName = fullName;
        Email = email;
        BirthDate = birthDate;
        Skills = skills;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public DateTime BirthDate { get; private set; }
    public List<string> Skills { get; private set; }

    public static UsersViewmodel FromEntity(User user)
    {
        var skills = user.Skills.Select(u => u.Skill.Description).ToList();

        return new UsersViewmodel(user.FullName, user.Email, user.BirthDate, skills);
    }
}