using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPi;

namespace demoAPI.Models
{
    public class AuthenMiddleWare
    {
        private readonly RequestDelegate _next;
        
        public AuthenMiddleWare (RequestDelegate next) => _next = next;
        
        public async Task Invoke (HttpContext httpContext )
        {
            if (httpContext.Request.Path != "/User" && httpContext.Request.Path != "/Record") {
                string Token = httpContext.Request.Headers["token"];
                    User user = new User();
                    string check = user.ValidateToken(Token);
                    if (check != null) await _next (httpContext);
                    else
                    {
                        await Task.Run(
                            async () =>
                            {
                                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                                await httpContext.Response.WriteAsJsonAsync(new {msg = "Fail to Authenication Token"});
                            });
                    }
            }
            else await _next (httpContext);
        }
    }
}
