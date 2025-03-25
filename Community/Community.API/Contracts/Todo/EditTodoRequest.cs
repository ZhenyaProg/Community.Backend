namespace Community.API.Contracts.Todo
{
    public class EditTodoRequest
    {
        public string Title { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Deadline { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}