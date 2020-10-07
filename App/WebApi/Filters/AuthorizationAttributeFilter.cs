using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters
{
    public class AuthorizationAttributeFilter : Attribute, IAuthorizationFilter
    {
        
    }
}