using DevFreela.Application.Models;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _context;

        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<UsersViewmodel>> GetAllUsers(string search = "")
        {
            var user = _context.Users
            .Where(u => !u.IsDeleted)
            .ToList();

            var model = user.Select(UsersViewmodel.FromEntity).ToList();

            return ResultViewModel<List<UsersViewmodel>>.Success(model);
        }

        public ResultViewModel<UsersViewmodel> GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return ResultViewModel<UsersViewmodel>.Erro("Usuário não encontrado.");
            }

            var model = UsersViewmodel.FromEntity(user);

            return ResultViewModel<UsersViewmodel>.Success(model);
        }

        public ResultViewModel<int> Post(CreateUserInputModel model)
        {
            var user = model.ToEntity();

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(user.Id);
        }

        public ResultViewModel<int> PostSkills(int id, UserSkillsInputModel model)
        {
            var userSkills = model.SkillsIds.Select(s => new UserSkill(id, s)).ToList();

            _context.UserSkills.AddRange(userSkills);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(model.Id);
        }
    }
}
