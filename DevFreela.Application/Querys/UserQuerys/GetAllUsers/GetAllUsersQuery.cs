using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.UserQuerys.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<ResultViewModel<List<UsersViewmodel>>>
    {

    }
}
