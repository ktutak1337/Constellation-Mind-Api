using ConstellationMind.Infrastructure.Services.Commands;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        private static readonly string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])";
        private static readonly string ErrorMessage = "Invalid Password: 'password' must contain at least one number, at least one uppercase letter, at least one lowercase letter, and at least one special character.";

        public ChangePasswordValidator()
        {
            RuleFor(player => player.CurrentPassword)
                .NotEmpty()
                .Matches(PasswordRegex)
                .WithMessage(ErrorMessage)
                .Length(8, 64);

            RuleFor(player => player.NewPassword)
                .NotEmpty()
                .Matches(PasswordRegex)
                .WithMessage(ErrorMessage)
                .Length(8, 64);    
        }
    }
}
