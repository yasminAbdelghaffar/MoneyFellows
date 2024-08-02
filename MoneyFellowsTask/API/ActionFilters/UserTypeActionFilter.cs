using API.Utilities;
using Core.Enums;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace API.ActionFilters
{
    public class UserTypeActionFilter : Attribute, IAsyncActionFilter
    {
        private const string UserNotAuthorized = "User Not Authorized.";
        private readonly UserType[] _allowedUserTypes;

        public UserTypeActionFilter(params UserType[] userTypes)
        {
            _allowedUserTypes = userTypes;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string requestUserType = context.HttpContext.Items["UserType"].ToString();
            if (!string.IsNullOrWhiteSpace(requestUserType) && IsAllowedUser(requestUserType))
            {
                await next();
            }
            else
            {
                await HttpResponseUtilities.SetContextResponseAsync(context.HttpContext, new { ErrorDetail = UserNotAuthorized }, HttpStatusCode.Unauthorized);
            }
        }

        private bool IsAllowedUser(string requestUserType)
        {
            bool isValidUser = Enum.TryParse(requestUserType, out UserType callingUserType);

            if (isValidUser && _allowedUserTypes.Contains(callingUserType))
                return true;
            return false;
        }
    }
}

