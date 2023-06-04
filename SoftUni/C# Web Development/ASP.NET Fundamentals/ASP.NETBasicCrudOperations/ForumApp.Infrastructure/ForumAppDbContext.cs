namespace ForumApp.Infrastructure
{
    using Microsoft.EntityFrameworkCore;

    using ForumApp.Infrastructure.Models;
    using ForumApp.Infrastructure.Configuration;

    public class ForumAppDbContext : DbContext
    {
        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options)
            : base(options)
        {

        }

        //-- Place for the DB sets --//
        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PostEntityConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
