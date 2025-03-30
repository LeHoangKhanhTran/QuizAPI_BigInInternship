using System.Net;
using Microsoft.AspNetCore.Authorization;

public static class AdminAndUserResourcePolicy
{
    public const string Name = "AdminAndUserResourcePolicy";
    public static void AddPolicy(AuthorizationOptions options)
    {
        options.AddPolicy(Name, policy =>
        {
            // policy.Requirements.Add(new RolesRequirement(new List<string> {"Admin", "User"}));
            policy.Requirements.Add(new UserResourceRequirement());
            policy.RequireAuthenticatedUser();
        });
    }
}