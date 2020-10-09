using System;
using Contracts;
using Microsoft.AspNetCore.Mvc;
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
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                Guid token = Guid.Parse(context.HttpContext.Request.Headers["Authorization"]);
                if(!this.sessionsLogic.IsCorrectToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        StatusCode = 403,
                        Content = "Not authorized"
                    };
                }
            }
            catch (ArgumentNullException)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Authorization required"
                };
            }
            catch (Exception)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Problem with parse"
                };
            }
        }
        private ISessionLogic GetSessionLogic(AuthorizationFilterContext context)
        {
            var sessionType = typeof(ISessionLogic);

            return context.HttpContext.RequestServices.GetService(sessionType) as ISessionLogic;
        }
    }
}