using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Models;

namespace Portfolio.Infrastructure
{
    public class PortfolioDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
          : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            const string connectionString = "Server=192.168.31.26;Database=PortfolioBase;User Id=Portfolio;Password=333;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);


                entity.Property(e => e.Username)
                  .IsRequired()
                  .HasMaxLength(50);
                entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(50);
                entity.Property(e => e.PasswordHash)
                  .IsRequired()
                  .HasMaxLength(255);

                // Relationships (optional)
                // entity.HasMany(u => u.Projects)
                //   .WithOne(p => p.User)
                //   .HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.Title)
                  .IsRequired()
                  .HasMaxLength(50);
                entity.Property(e => e.Description);

            });

            //modelBuilder.Entity<Comment>(entity =>
            //{
            //    entity.HasKey(e => e.CommentId);


            //    entity.Property(e => e.Content)
            //      .IsRequired();
            //    entity.Property(e => e.Timestamp);

            //    entity.HasOne(c => c.User)
            //      .WithMany(u => u.Comments) 
            //      .HasForeignKey(c => c.UserId);
            //});
        }
    }
}
