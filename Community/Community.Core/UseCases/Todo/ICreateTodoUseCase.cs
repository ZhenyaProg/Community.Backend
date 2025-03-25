namespace Community.Core.UseCases.Todo
{
    public interface ICreateTodoUseCase
    {
        Task Execute(CreateTodoCommand command, CancellationToken token);
    }
}