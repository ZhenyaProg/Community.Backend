namespace Community.Core.UseCases.Todo
{
    public record CreateTodoCommand(string Title,
                                    bool Success,
                                    string Deadline,
                                    string Description);
}