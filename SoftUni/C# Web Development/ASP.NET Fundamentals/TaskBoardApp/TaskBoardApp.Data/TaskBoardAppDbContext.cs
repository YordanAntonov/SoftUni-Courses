namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using TaskBoardApp.Data.DataConfig;
    using TaskBoardApp.Data.Models;
    using Task = Models.Task;

    public class TaskBoardAppDbContext : IdentityDbContext
    {
        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Board> Boards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Task>()
                .HasOne(b => b.Board)
                .WithMany(t => t.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.ApplyConfiguration(new BoardSettings());
            modelBuilder.ApplyConfiguration(new TaskSettings());

            base.OnModelCreating(modelBuilder);
        }
    }
}