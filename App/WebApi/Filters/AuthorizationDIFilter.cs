using Contracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class AuthorizationDIFilter : IAuthorizationFilter
    {
        private readonly ISessionLogic sessionsLogic;

         public AuthorizationDIFilter(ISessionLogic sessions)
        {
            this.sessionsLogic = sessions;
        }

        
    }
}