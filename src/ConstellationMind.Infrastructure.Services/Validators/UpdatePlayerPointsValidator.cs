using System;
using ConstellationMind.Infrastructure.Services.Commands.Players;
using FluentValidation;

namespace ConstellationMind.Infrastructure.Services.Validators
{
    public class UpdatePlayerPointsValidator : AbstractValidator<UpdatePlayerPoints>
    {
        public UpdatePlayerPointsValidator()
        {
            RuleFor(player => player.Points)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
