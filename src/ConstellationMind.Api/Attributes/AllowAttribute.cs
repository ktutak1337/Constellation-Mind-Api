using Microsoft.AspNetCore.Authorization;

namespace ConstellationMind.Api.Attributes
{
    public class AllowAttribute : AuthorizeAttribute
    {
        public AllowAttribute(params string[] roles) 
            => Roles = string.Join(",", roles);
    }
}
