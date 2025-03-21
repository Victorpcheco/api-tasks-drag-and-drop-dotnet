using Api.Models;
using FluentValidation;

namespace Api.Validators;

public class TaskModelValidator : AbstractValidator<TaskModel>
{
    public TaskModelValidator()
    {
        RuleFor(t => t.Titulo)
            .NotNull().WithMessage("O campo titulo não pode ser nulo.")
            .NotEmpty().WithMessage("o campo titulo não pode ser enviado em branco.");
            
        RuleFor(t => t.Status)
            .NotEmpty().WithMessage("O status é obrigatório.")
            .Must(s => s == "Pendente" || s == "Concluído")
            .WithMessage("O status deve ser 'Pendente' ou 'Concluído'.");
    }
}