using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

public class UserResourceHandler : AuthorizationHandler<UserResourceRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UserResourceHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserResourceRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext is null) return Task.CompletedTask;
        var user = httpContext.User;
        if (user is null) return Task.CompletedTask;
        var queryUserId = httpContext.Request.Query["userId"];
        var userId = user.Claims.Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Select(c => c.Value).SingleOrDefault();
        var roles = user.Claims.Where(c => c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role");
        if ((string.IsNullOrEmpty(queryUserId) && roles.Any(r => r.Value == "Admin")) || queryUserId.ToString() == userId) context.Succeed(requirement);
        return Task.CompletedTask;
    }
}