using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Filters
{
    [ExcludeFromCodeCoverage]
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                throw context.Exception;
            }
            catch (ArgumentException e)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 400,
                    Content = e.Message
                };
            }
            catch (AggregateException e)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = e.Message
                };
            }
            catch(Exception)
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 500,
                    Content = "Server error :" + context.Exception.Message,
                };
            }
        }
    }
}