using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Entities;

public class QuizDbContext: DbContext
{
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Choice> Choices { get; set; }
    public DbSet<Record> Records { get; set; }
    public DbSet<Answer> Answers { get; set; }
    private readonly IConfiguration _config;
    public QuizDbContext(IConfiguration config)
    {
        _config = config;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(_config["Database:ConnectionString"], 
        ServerVersion.AutoDetect(_config["Database:ConnectionString"]));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Topic>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description).IsRequired();
            entity.HasMany(e => e.Questions).WithMany(q => q.Topics);
            entity.HasMany(e => e.Records).WithOne(r => r.Topic);
        });

        modelBuilder.Entity<Question>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Content).IsRequired();
            entity.Property(e => e.CorrectChoiceID).IsRequired();
            entity.HasMany(e => e.Choices).WithOne(c => c.Question);
            entity.HasMany(e => e.Topics).WithMany(t => t.Questions);
            entity.Navigation(e => e.Choices).AutoInclude();
        });

        modelBuilder.Entity<Choice>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Content).IsRequired();
            entity.HasOne(e => e.Question).WithMany(q => q.Choices);
        });

        modelBuilder.Entity<Record>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.UserID).IsRequired();
            entity.Property(e => e.Score).IsRequired();
            entity.Property(e => e.CreatedDate)
                  .HasConversion(d => d.UtcDateTime, d => new DateTimeOffset(d, TimeSpan.Zero) )
                  .IsRequired();
            entity.HasOne(e => e.Topic).WithMany(t => t.Records);
            entity.HasMany(e => e.Answers).WithOne(a => a.Record);
            entity.Navigation(e => e.Answers).AutoInclude();
        });

        modelBuilder.Entity<Answer>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.QuestionId).IsRequired();
            entity.Property(e => e.ChoiceId).IsRequired();
            entity.HasOne(e => e.Record).WithMany(r => r.Answers);
        });
    }
}
