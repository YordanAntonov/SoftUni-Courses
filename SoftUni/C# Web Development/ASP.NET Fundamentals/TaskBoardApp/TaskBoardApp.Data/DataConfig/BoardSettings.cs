namespace TaskBoardApp.Data.DataConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TaskBoardApp.Data.Models;
    public class BoardSettings : IEntityTypeConfiguration<Board>
    {
        private readonly BoardSeeding boardSeeder;
        public BoardSettings()
        {
            boardSeeder = new BoardSeeding();
        }

        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(this.boardSeeder.GenerateBoards());
        }
    }
}
