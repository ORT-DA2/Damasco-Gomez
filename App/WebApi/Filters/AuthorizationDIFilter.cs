using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SessionInterface;

namespace Filters
{
    public class AuthorizationDIFilter : IAuthorizationFilter
    {
        private readonly ISessionLogic sessionsLogic;

         public AuthorizationDIFilter(ISessionLogic sessions)
        {
            this.sessionsLogic = sessions;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];

            if(string.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Authorization required"
                };
            }
            else
            {
                if(!this.sessionsLogic.isCorrectToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "you don't have permits"
                    };
                }
            }
        }
        private ISessionLogic GetSessionLogic(AuthorizationFilterContext context)
        {
            var sessionType = typeof(ISessionLogic);

            return context.HttpContext.RequestServices.GetService(sessionType) as ISessionLogic;
        }
        
    }
}