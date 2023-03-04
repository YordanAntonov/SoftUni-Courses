using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using P02_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data;

public class StudentSystemContext : DbContext
{
    //Always one empty constructor for us!!
    public StudentSystemContext()
    {
        
    }

    
    //This constructor is for Judge, he is woking with it!
    public StudentSystemContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Resource> Resources { get; set; } = null!;
    public DbSet<Homework> Homeworks { get; set; } = null!;
    public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;

    //Here we put the connection string!
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //If not configured put the connection string
            optionsBuilder.UseSqlServer(Config.CONNECTION_STRING);
        }

        base.OnConfiguring(optionsBuilder);
    }

    //Here stays the Fluent API
    // TODO: Write Fluent API config

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(s =>
        {
            s.Property(s => s.PhoneNumber)
            .IsUnicode(false);
        });

        modelBuilder.Entity<Resource>(r =>
        {
            r.Property(r => r.Url)
            .IsUnicode(false);
        });

        modelBuilder.Entity<Homework>(h =>
        {
            h.Property(h => h.Content)
            .IsUnicode(false);
        });

        modelBuilder.Entity<StudentCourse>(sc =>
        {
            sc.HasKey(sc => new { sc.StudentId, sc.CourseId }); //This is creating composite primary key

            sc.HasOne(sc => sc.Student)
            .WithMany(s => s.StudentsCourses)
            .HasForeignKey(sc => sc.StudentId);

            sc.HasOne(sc => sc.Course)
            .WithMany(c => c.StudentsCourses)
            .HasForeignKey(sc => sc.CourseId);
        });

        base.OnModelCreating(modelBuilder);
    }
}