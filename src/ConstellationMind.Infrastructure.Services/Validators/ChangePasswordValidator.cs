using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Shared.Exceptions;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        private static readonly string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])";
        private static readonly string RegexErrorMessage = "must contain at least one number, at least one uppercase letter, at least one lowercase letter, and at least one special character.";

        public ChangePasswordValidator()
        {
            RuleFor(command => command.CurrentPassword)
                .NotEmpty()
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPassword, "'CurrentPassword' can not be empty."))
                .Matches(PasswordRegex)
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPassword, $"'CurrentPassword' {RegexErrorMessage}."))
                .Length(8, 64)
                .OnFailure((command) => throw new ConstellationMindException(ErrorCodes.InvalidPassword, 
                    $"'CurrentPassword' must be between 8 and 64 characters. You entered {command.CurrentPassword.Length} characters."));

            RuleFor(command => command.NewPassword)
                .NotEmpty()
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPassword, "'NewPassword' can not be empty."))
                .Matches(PasswordRegex)
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPassword, $"'NewPassword' {RegexErrorMessage}."))
                .Length(8, 64)
                .OnFailure((command) => throw new ConstellationMindException(ErrorCodes.InvalidPassword, 
                    $"'NewPassword' must be between 8 and 64 characters. You entered {command.NewPassword.Length} characters."));    
        }
    }
}
