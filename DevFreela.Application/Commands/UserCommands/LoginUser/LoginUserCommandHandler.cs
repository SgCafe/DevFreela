using DevFreela.Application.Models;
using DevFreela.Application.UtilMessage;
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

        public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //Utiliza o mesmo algoritmo para criar o Hash da senha
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            //Busca no banco de dados um user que tenha email e senha com formato Hash
            var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);
            //Se não existir, erro no login
            if (user is null)
            {
                return null;
            }

            //Se existir, gera o Token usando os dados do usuário
            var token = _authService.GenerateJwtToken(user.Email, user.Role);
            var loginUserViewModel = new LoginUserViewModel(user.Email, token);
            return ResultViewModel<LoginUserViewModel>.Success(loginUserViewModel);
        }
    }
}
