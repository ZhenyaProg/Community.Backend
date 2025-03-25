namespace Community.Core.UseCases.Todo
{
    public interface IDeleteTodoByIdUseCase
    {
        Task Execute(DeleteTodoCommand command, CancellationToken token);
    }
}