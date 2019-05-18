using ConstellationMind.Infrastructure.Services.Commands;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class CreatePlayerValidator : AbstractValidator<CreatePlayer>
    {
        public CreatePlayerValidator()
        {
            RuleFor(player => player.FirstName)
                .Matches(@"^[a-zA-Z]+$")
                .WithMessage("'FirstName' must contain only letters.");
            
            RuleFor(player => player.Nickname)
                .NotEmpty()
                .Matches(@"^[a-zA-Z0-9_!@#$%&]+$")
                .WithMessage("'Nickname' must contain only letters or digits or special characters [_ ! @ # $ % &].");
                       
            RuleFor(player => player.Password)
                .NotEmpty()
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])")
                .WithMessage("Invalid Password: 'password' must contain at least one number, at least one uppercase letter, at least one lowercase letter, and at least one special character.")
                .Length(8, 64);  

            RuleFor(player => player.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
