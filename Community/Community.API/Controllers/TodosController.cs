using Community.API.Contracts.Todo;
using Community.Core.UseCases.Todo;
using Microsoft.AspNetCore.Mvc;

namespace Community.API.Controllers
{
    [ApiController]
    [Route("api/todos")]
    public class TodosController : ControllerBase
    {
        [HttpPost()]
        public async Task<IResult> CreateTodo(
            [FromBody] CreateTodoRequest request,
            [FromServices] ICreateTodoUseCase useCase,
            CancellationToken token)
        {
            var command = new CreateTodoCommand(request.Title, request.Success, request.Deadline, request.Description);
            await useCase.Execute(command, token);
            return Results.Created();
        }

        [HttpGet()]
        public async Task<IResult> GetTodosByPage(
            [FromQuery] int page, [FromQuery] int pageSize,
            [FromServices] IGetTodoByPageUseCase useCase,
            CancellationToken token)
        {
            var query = new GetTodoByPageQuery(page, pageSize);
            var todos = await useCase.Execute(query, token);
            return Results.Ok(todos);
        }

        [HttpGet()]
        [Route("{id:guid}")]
        public async Task<IResult> GetTodoById(
            [FromRoute] Guid id,
            [FromServices] IGetTodoByIdUseCase useCase,
            CancellationToken token)
        {
            var query = new GetTodoByIdQuery(id);
            var todo = await useCase.Execute(query, token);
            return Results.Ok(todo);
        }

        [HttpPut()]
        public async Task<IResult> EditTodoById(
            [FromQuery] Guid editedId,
            [FromBody] EditTodoRequest request,
            [FromServices] IEditTodoUseCase useCase,
            CancellationToken token)
        {
            var query = new EditTodoCommand(editedId, request.Title, request.Success, request.Deadline, request.Description);
            await useCase.Execute(query, token);
            return Results.Ok();
        }

        [HttpDelete()]
        public async Task<IResult> DeleteTodoById(
            [FromQuery] Guid deletedId,
            [FromServices] IDeleteTodoByIdUseCase useCase,
            CancellationToken token) 
        {
            var command = new DeleteTodoCommand(deletedId);
            await useCase.Execute(command, token);
            return Results.Ok();
        }
    }
}