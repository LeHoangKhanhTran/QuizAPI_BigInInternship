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
        var token = httpContext.Request.Cookies["access_token"];
        if (string.IsNullOrEmpty(token)) return Task.CompletedTask;
        var jwtHandler = new JwtSecurityTokenHandler();
        var jwtToken = jwtHandler.ReadJwtToken(token);
        if (jwtToken is null) return Task.CompletedTask;
        var queryUserId = httpContext.Request.Query["userId"];
        var userId = jwtToken.Claims.Where(c => c.Type == JwtRegisteredClaimNames.Sub).Select(c => c.Value).SingleOrDefault();
        if (string.IsNullOrEmpty(queryUserId) || queryUserId.ToString() == userId) context.Succeed(requirement);
        return Task.CompletedTask;
    }
}