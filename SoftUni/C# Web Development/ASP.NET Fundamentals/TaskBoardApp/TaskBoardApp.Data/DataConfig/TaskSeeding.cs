namespace TaskBoardApp.Data.DataConfig
{
    using Task = TaskBoardApp.Data.Models.Task;

    internal class TaskSeeding
    {
        internal Task[] SeedTasks()
        {
            ICollection<Task> tasks = new List<Task>();

            Task currTask;

            currTask = new Task()
            {
                Id = 1,
                Title = "Improve CSS styles",
                Description = "Implement better styling for all public pages",
                CreatedOn = DateTime.UtcNow.AddDays(-200),
                OwnerId = "3beadded-107d-4357-956e-d490754c07b3",
                BoardId = 1
            };

            tasks.Add(currTask);

            currTask = new Task()
            {
                Id = 2,
                Title = "Android Client App",
                Description = "Create Android Client App for the TaskBoard RESTful API",
                CreatedOn = DateTime.UtcNow.AddDays(-10),
                OwnerId = "3beadded-107d-4357-956e-d490754c07b3",
                BoardId = 2
            };

            tasks.Add(currTask);

            currTask = new Task()
            {
                Id = 3,
                Title = "Desktop Client App",
                Description = "Create Windows Forms desktop app client for the taskBoard App RESTful API",
                CreatedOn = DateTime.UtcNow.AddDays(-40),
                OwnerId = "3beadded-107d-4357-956e-d490754c07b3",
                BoardId = 3
            };

            tasks.Add(currTask);

            return tasks.ToArray();
        }
    }
}
