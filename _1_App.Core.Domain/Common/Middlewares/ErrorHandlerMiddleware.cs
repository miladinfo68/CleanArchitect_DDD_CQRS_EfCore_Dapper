using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using _1_App.Core.Domain.Common.Response;
using _1_App.Core.Domain.Common.Execptions;
using System.ComponentModel.DataAnnotations;
using System.Security.Authentication;

namespace _1_App.Core.Domain.Common.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next) => _next = next;
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = ApiResponse<string>.Fail(error.Message);
                switch (error)
                {
                    // custom application error
                    case CustomException e:
                    case ValidationException _:
                    case FormatException _:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case AuthenticationException _:
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case NotImplementedException _:
                        response.StatusCode = (int)HttpStatusCode.NotImplemented;
                        break;
                    case KeyNotFoundException _:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }
    }
}
