using System;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string token = context.HttpContext.Request.Headers["Authorization"];

            if(String.IsNullOrEmpty(token))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Unauthorized : A token is required"
                };
            }
            else
            {
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
        }

        private ISessionLogic GetSessionLogic(AuthorizationFilterContext context)
        {
            var sessionType = typeof(ISessionLogic);

            return context.HttpContext.RequestServices.GetService(sessionType) as ISessionLogic;
        }
    }
}