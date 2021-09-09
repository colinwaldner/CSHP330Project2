using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LearningCenter.Service.Models;

namespace LearningCenter.Service
{
    public class AuthenticatorAttribute : TypeFilterAttribute
    {
        public AuthenticatorAttribute() : base(typeof(AuthenticatorActionFilter))
        {

        }
    }

    public class AuthenticatorActionFilter : IAuthorizationFilter
    {
        private const string BEARER = "Bearer ";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                bool valid = false;

                var request = context.HttpContext.Request;

                var authorization = request.Headers["Authorization"].ToString();
                if (authorization.StartsWith(BEARER))
                {
                    var tokenString = authorization.Substring(BEARER.Length).Trim();
                    var token = TokenHelper.DecodeToken(tokenString);
                    if (token != null)
                        valid = true;
                }

                if (!valid)
                {
                    context.Result = new ObjectResult(new ApiResponse(401));
                }
            }
            catch (Exception ex)
            {
                context.Result = new ObjectResult(new ApiResponse(401));
            }
        }
    }
}
