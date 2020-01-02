using ConstellationMind.Infrastructure.Services.Commands.Accounts;
using ConstellationMind.Shared.Exceptions;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class SignUpValidator : AbstractValidator<SignUp>
    {
        public SignUpValidator()
        {
            RuleFor(command => command.Password)
                .NotEmpty()
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPassword, "'Password' can not be empty."))
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z])")
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPassword, 
                    "'Password' must contain at least one number, at least one uppercase letter, at least one lowercase letter, and at least one special character."))
                .Length(8, 64)
                .OnFailure((command) => throw new ConstellationMindException(ErrorCodes.InvalidPassword, 
                    $"'Password' must be between 8 and 64 characters. You entered {command.Password.Length} characters."));

            RuleFor(command => command.Email)
                .NotEmpty()
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidEmail, "'Email' can not be empty."))
                .EmailAddress();

            RuleFor(command => command.FirstName)
                .Matches(@"^[a-zA-Z]+$")
                .OnAnyFailure((command) => throw new ConstellationMindException(ErrorCodes.InvalidFirstName,
                    $"Invalid 'Firstname': {command.FirstName}. 'FirstName' must contain only letters."));
            
            RuleFor(command => command.Nickname)
                .NotEmpty()
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidNickname, "'Nickname' can not be empty."))
                .Matches(@"^[a-zA-Z0-9_!@#$%&]+$")
                .OnFailure((command) => 
                    throw new ConstellationMindException(ErrorCodes.InvalidNickname, 
                        $"Invalid 'Nickname': {command.Nickname}.'Nickname' must contain only letters or digits or special characters [_ ! @ # $ % &]."));

            RuleFor(command => command.Role)
                .NotEmpty()
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidRole, "'Role' can not be empty."));
        }
    }
}
