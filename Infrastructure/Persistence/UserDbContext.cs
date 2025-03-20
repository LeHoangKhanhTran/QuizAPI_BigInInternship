using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Entities;

public class UserDbContext: IdentityDbContext<User>
{
    private readonly IConfiguration _config;
    public UserDbContext(IConfiguration config)
    {
        _config = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_config["Database:ConnectionString"], 
        ServerVersion.AutoDetect(_config["Database:ConnectionString"]));
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "0", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "1", Name = "User", NormalizedName = "USER" }
        );
    }
}

