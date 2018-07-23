using FluentValidation;

namespace DemoMediatR.Application.Commands.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public CreateUserValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(a => a.Email)
                .EmailAddress()
                .WithMessage("Invalid email");

            RuleFor(a => a.Password)
                .NotEmpty()
                .WithMessage("Password is required");

            RuleFor(a => a.ConfirmPassword)
                .NotEmpty()
                .WithMessage("A Confirmação de Senha é obrigatória");

            RuleFor(a => a.ConfirmPassword)
                .Equal(b=> b.Password)
                .WithMessage("Passwords do not match");
        }
    }
}