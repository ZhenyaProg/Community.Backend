namespace Community.Application.Exceptions
{

    public class TodoNotFoundException : DomainException
    {
        public TodoNotFoundException(Guid todoId) :
            base(DomainErrorCodes.Gone, $"Todo with id {todoId} was not found")
        {

        }
    }
}