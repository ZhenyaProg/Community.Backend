namespace Community.Core.UseCases.Todo
{
    public interface IEditTodoUseCase
    {
        Task Execute(EditTodoCommand query, CancellationToken token);
    }
}