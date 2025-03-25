namespace Community.Core.UseCases.Todo
{
    public record EditTodoCommand(Guid EditedId, string Title, bool Success, string Deadline, string Description);
}