namespace TaskBoardApp.Data.DataConfig
{
    using TaskBoardApp.Data.Models;

    internal class BoardSeeding
    {
        internal Board[] GenerateBoards()
        {
            ICollection<Board> boards = new List<Board>();

            Board currBoard;

            currBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            boards.Add(currBoard);

            currBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            boards.Add(currBoard);

            currBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };

            boards.Add(currBoard);

            return boards.ToArray();
        }
    }
}
