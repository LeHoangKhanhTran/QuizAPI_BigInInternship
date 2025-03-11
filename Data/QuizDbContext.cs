using Microsoft.EntityFrameworkCore;
using QuizAPI.Entities;

public class QuizContext: DbContext 
{
    public DbSet<Topic> Topic { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Choice> Choice { get; set; }
    public DbSet<Record> Record { get; set; }
    public DbSet<Answer> Answer { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // TODO: Add connection string to dabase
        optionsBuilder.UseMySql("server=localhost;database=;user=;password=", 
        ServerVersion.AutoDetect("server=localhost;database=;user=;password="));
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
            entity.HasOne(e => e.CorrectChoice).WithOne(c => c.Quesition);
            entity.HasMany(e => e.Choices).WithOne(c => c.Quesition);
            entity.HasMany(e => e.Topics).WithMany(t => t.Questions);
        });

        modelBuilder.Entity<Choice>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.Content);
            entity.HasOne(e => e.Quesition).WithMany(q => q.Choices);
        });

        modelBuilder.Entity<Record>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.UserID).IsRequired();
            entity.Property(e => e.Score).IsRequired();
            entity.HasOne(e => e.Topic).WithMany(t => t.Records);
            entity.HasMany(e => e.Answers).WithOne(a => a.Record);
        });

        modelBuilder.Entity<Answer>(entity => 
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.QuestionId);
            entity.Property(e => e.Choice);
            entity.HasOne(e => e.Record).WithMany(r => r.Answers);
        });
    }
}