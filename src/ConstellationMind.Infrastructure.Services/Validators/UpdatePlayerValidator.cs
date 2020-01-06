using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Shared.Exceptions;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class UpdatePlayerValidator : AbstractValidator<UpdatePlayer>
    {
        public UpdatePlayerValidator()
        {
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
        }
    }
}
