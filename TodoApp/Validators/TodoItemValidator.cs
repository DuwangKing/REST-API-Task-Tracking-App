using FluentValidation;
using TodoApp.Models;

namespace TodoApp.Validators;

public class TodoItemValidator : AbstractValidator<TodoItem>
{
    public TodoItemValidator()
    {
        RuleFor(todo => todo.Title)
            .NotEmpty().WithMessage("Title is required")
            .MinimumLength(3).WithMessage("Title must be at least 3 characters")
            .MaximumLength(100).WithMessage("Title cannot exceed 100 characters");
    }
}