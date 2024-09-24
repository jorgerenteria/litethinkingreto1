namespace Application.UseCases.TodoList.Queries.GetTasks
{
    public class GetTasksDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
