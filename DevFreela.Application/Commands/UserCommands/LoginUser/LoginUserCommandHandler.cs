using DevFreela.Application.Models;
using DevFreela.Core.Services;
using MediatR;

namespace DevFreela.Application.Commands.UserCommands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public LoginUserCommandHandler(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepository = userRepository;
        }

        public Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utiliza o mesmo algoritmo para criar o Hash da senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Busca no banco de dados um user que tenha email e senha com formato Hash

            //Se não existir, erro no login

            //Se existir, gera o Token usando os dados do usuário

        }
    }
}
