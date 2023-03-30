namespace Footballers.Data
{
    using Footballers.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class FootballersContext : DbContext
    {
        public FootballersContext() 
        {

        }

        public FootballersContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Footballer> Footballers { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Coach> Coaches { get; set; } = null!;
        public DbSet<TeamFootballer> TeamsFootballers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString)
                    .UseLazyLoadingProxies();
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TO DO: Make the Primary key of Map table!
            modelBuilder.Entity<TeamFootballer>(entity =>
            {
                entity.HasKey(ps => new { ps.TeamId, ps.FootballerId });               
            });
        } 
    }
}
