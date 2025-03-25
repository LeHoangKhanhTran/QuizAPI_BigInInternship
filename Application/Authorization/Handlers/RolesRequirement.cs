using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

public class RolesRequirementHandler : AuthorizationHandler<RolesRequirement>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public RolesRequirementHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesRequirement requirement)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext is null) return Task.CompletedTask;
        var token = httpContext.Request.Cookies["access_token"];
        if (string.IsNullOrEmpty(token)) return Task.CompletedTask;
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);
        if (jwtToken is null) return Task.CompletedTask;
        var roles = jwtToken.Claims.Where(c => c.Type == "role").Select(c => c.Value).ToList();
        var requiredRoles = requirement.Roles;
        var queryUserId = httpContext.Request.Query["userId"];
        if (string.IsNullOrEmpty(queryUserId)) requiredRoles = [.. requiredRoles.Where(r => r != "User")];
        foreach (var role in roles)
        {
            if (requiredRoles.Contains(role))
            {
                context.Succeed(requirement);
                break;
            }
        }
        return Task.CompletedTask;
    }
}