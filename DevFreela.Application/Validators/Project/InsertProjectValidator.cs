using DevFreela.Application.Commands.ProjectCommands.InsertProject;
using DevFreela.Application.UtilMessage;
using FluentValidation;

namespace DevFreela.Application.Validators.Project
{
    public class InsertProjectValidator : AbstractValidator<InsertProjectCommand>
    {
        public InsertProjectValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty()
                    .WithMessage(DialogMessage.NaoPodeSerVazio)
                .MaximumLength(50)
                    .WithMessage(DialogMessage.TamanhoMaximo(50));

            RuleFor(p => p.TotalCoast)
                .GreaterThanOrEqualTo(1000)
                    .WithMessage(DialogMessage.ValorMinimoProjeto(1000.00m));
        }

    }
}
