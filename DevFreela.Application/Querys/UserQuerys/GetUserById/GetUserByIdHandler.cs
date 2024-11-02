using DevFreela.Application.Models;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Querys.UserQuerys.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResultViewModel<UsersViewmodel>>
    {
        private readonly DevFreelaDbContext _context;

        public GetUserByIdHandler(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<UsersViewmodel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(u => u.Skills)
                    .ThenInclude(u => u.Skill)
                .SingleOrDefaultAsync(u => u.Id == request.Id);

            if (user is null)
            {
                return ResultViewModel<UsersViewmodel>.Erro("Usuário não encontrado.");
            }

            var model = UsersViewmodel.FromEntity(user);

            return ResultViewModel<UsersViewmodel>.Success(model);
        }
    }
}
