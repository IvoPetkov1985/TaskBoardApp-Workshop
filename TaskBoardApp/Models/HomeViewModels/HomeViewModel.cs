namespace TaskBoardApp.Models.HomeViewModels
{
    public class HomeViewModel
    {
        public int AllTasksCount { get; set; }

        public IList<HomeBoardModel> BoardsWithTasksCount { get; set; } = new List<HomeBoardModel>();

        public int UserTasksCount { get; set; }
    }
}
