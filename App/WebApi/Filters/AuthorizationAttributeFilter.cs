using System;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        private readonly ISessionLogic sessions;
        public AuthorizationAttributeFilter (ISessionLogic sessionsLogic)
        {
            this.sessions =  sessionsLogic;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                Guid token = Guid.Parse(context.HttpContext.Request.Headers["Authorization"]);
                var sessions = this.GetSessionLogic(context);
                if(!sessions.IsCorrectToken(token))
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
                    Content = "Unauthorized : A token is required"
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