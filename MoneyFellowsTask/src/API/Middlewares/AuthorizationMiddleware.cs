using API.Utilities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace API.Middlewares
{
    public class AuthorizationMiddleware
    {
        private const string InvalidJWTToken = "Invalid JWT Token";
        private const string Secret = "TW9uZXlGZWxsb3dzQHRhc2s=";
        private readonly RequestDelegate _next;
        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (await ValidatedToken(token, context))
                await _next.Invoke(context);
        }
        private async Task<bool> ValidatedToken(string token, HttpContext context)
        {
            try
            {
                if(context.Request.Path.ToString().Contains("swagger") || context.Request.Path.ToString().Contains("register") || context.Request.Path.ToString().Contains("login"))
                {
                    return true;
                }
                if (token == null)
                {
                    throw new ArgumentNullException(InvalidJWTToken);
                }
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret.PadRight((512 / 8), '\0'))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                context.Items["UserType"] = jwtToken.Claims.First(x => x.Type == "Roles").Value;
                context.Items["Username"] = jwtToken.Claims.First(x => x.Type == "Username").Value;
                return true;
            }
            catch
            {
                await HttpResponseUtilities.SetContextResponseAsync(context, new { ErrorDetail = InvalidJWTToken }, HttpStatusCode.Forbidden);
                return false;
            }
        }
    }
}
