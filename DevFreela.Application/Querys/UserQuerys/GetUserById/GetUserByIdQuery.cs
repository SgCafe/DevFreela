using DevFreela.Application.Models;
using MediatR;

namespace DevFreela.Application.Querys.UserQuerys.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UsersViewmodel>>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
