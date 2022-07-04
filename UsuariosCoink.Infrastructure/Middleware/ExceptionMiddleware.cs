using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsuariosCoink.Core.Application.Exceptions;

namespace UsuariosCoink.Infrastructure.Middleware
{

    internal class ExceptionMiddleware : IMiddleware
    {
        public ExceptionMiddleware()
        {

        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var errorResult = new ErrorResult
                {
                    Source = exception.TargetSite?.DeclaringType?.FullName,
                    Exception = exception.Message.Trim(),
                };
                errorResult.Messages!.Add(exception.Message);
                var response = context.Response;
                response.ContentType = "application/json";
                if (exception is not CustomException && exception.InnerException != null)
                {
                    while (exception.InnerException != null)
                    {
                        exception = exception.InnerException;
                    }
                }

                switch (exception)
                {
                    case CustomException e:
                        response.StatusCode = errorResult.StatusCode = (int)e.StatusCode;
                        if (e.ErrorMessages is not null)
                        {
                            errorResult.Messages = e.ErrorMessages;
                        }

                        break;

                    case KeyNotFoundException:
                        response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                await response.WriteAsync(JsonConvert.SerializeObject(errorResult));
            }
        }
    }
}

public class ErrorResult
{
    public List<string>? Messages { get; set; } = new();

    public string? Source { get; set; }
    public string? Exception { get; set; }
    public int StatusCode { get; set; }
}