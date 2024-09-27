using DevFreela.Application.Models;

namespace DevFreela.Application.Services.User
{
    public interface IUserService
    {
        ResultViewModel<List<UsersViewmodel>> GetAllUsers(string search = "");
        ResultViewModel<UsersViewmodel> GetById(int id);
        ResultViewModel<int> Post(CreateUserInputModel model);
        ResultViewModel<int> PostSkills(int id, UserSkillsInputModel model);
    }
}
