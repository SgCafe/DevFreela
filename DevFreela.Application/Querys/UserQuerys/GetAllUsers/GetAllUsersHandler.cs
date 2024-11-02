using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Querys.UserQuerys.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResultViewModel<List<UsersViewmodel>>>
    {
        private readonly DevFreelaDbContext _context;

        public GetAllUsersHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<List<UsersViewmodel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
            .Where(u => !u.IsDeleted)
            .ToListAsync();

            var model = user.Select(UsersViewmodel.FromEntity).ToList();

            return ResultViewModel<List<UsersViewmodel>>.Success(model);
        }
    }
}
