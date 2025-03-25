using Community.Core.UseCases.Todo;
using FluentValidation;

namespace Community.Application.Validators.Todo
{
    public class GetTodoByPageQueryValidator : AbstractValidator<GetTodoByPageQuery>
    {
        public GetTodoByPageQueryValidator()
        {
            RuleFor(query => query.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(query => query.PageSize)
                .GreaterThanOrEqualTo(1);
        }
    }
}