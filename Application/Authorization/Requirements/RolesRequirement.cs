using Microsoft.AspNetCore.Authorization;

public class RolesRequirement: IAuthorizationRequirement
{
    public List<string> Roles { get; }
    public RolesRequirement(List<string> roles)
    {
        Roles = roles;
    }
}