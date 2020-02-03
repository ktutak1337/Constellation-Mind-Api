using System;
using System.Text.Json.Serialization;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Players
{
    public class DeletePlayer : ICommand
    {
        [JsonIgnore]
        public Guid PlayerId { get; set; }
    }
}
