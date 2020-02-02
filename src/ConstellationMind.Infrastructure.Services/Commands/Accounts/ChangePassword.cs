using System;
using System.Text.Json.Serialization;
using ConstellationMind.Shared.Types;

namespace ConstellationMind.Infrastructure.Services.Commands.Accounts
{
    public class ChangePassword : ICommand
    {
        [JsonIgnore]
        public Guid PlayerId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }    
    }
}
