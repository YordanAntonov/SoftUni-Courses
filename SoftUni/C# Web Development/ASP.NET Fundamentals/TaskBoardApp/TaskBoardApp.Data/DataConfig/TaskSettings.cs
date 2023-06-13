namespace TaskBoardApp.Data.DataConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Task = Models.Task;

    public class TaskSettings : IEntityTypeConfiguration<Task>
    {
        private readonly TaskSeeding taskSeeder;

        public TaskSettings()
        {
            taskSeeder = new TaskSeeding();
        }
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasData(this.taskSeeder.SeedTasks());
        }
    }
}
