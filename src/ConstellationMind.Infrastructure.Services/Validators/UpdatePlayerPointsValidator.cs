using ConstellationMind.Infrastructure.Services.Commands.Players;
using ConstellationMind.Shared.Exceptions;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class UpdatePlayerPointsValidator : AbstractValidator<UpdatePlayerPoints>
    {
        public UpdatePlayerPointsValidator()
        {
            RuleFor(command => command.Points)
                .GreaterThan(0)
                .OnFailure(_ => throw new ConstellationMindException(ErrorCodes.InvalidPoints, "'Points' must be greater than '0'."));
        }
    }
}
