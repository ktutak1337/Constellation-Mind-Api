using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace ConstellationMind.Infrastructure.Services.Authentication
{
    public class Jwt
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public long Expires { get; set; }
        public string Id { get; set; }
        public string Role { get; set; }
        public IDictionary<string, string> Claims { get; set; }
    }
}
