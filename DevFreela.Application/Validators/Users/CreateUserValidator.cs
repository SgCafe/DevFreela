using DevFreela.Application.Commands.UserCommands.InsertUser;
using DevFreela.Application.UtilMessage;
using FluentValidation;

namespace DevFreela.Application.Validators.Users
{
    public class CreateUserValidator : AbstractValidator<InsertUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                    .WithMessage(DialogMessage.EmailInvalido);

            RuleFor(u => u.BirthDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage(DialogMessage.IdadeInvalida);
        }
    }
}
