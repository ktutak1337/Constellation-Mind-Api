using System;
using System.Text.Json.Serialization;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Accounts
{
    public class ChangeStatus : ICommand
    {
        [JsonIgnore]
        public Guid PlayerId { get; set; }
        public bool IsActive { get; set; }
    }
}
