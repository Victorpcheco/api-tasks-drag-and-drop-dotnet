using Api.Dto;
using FluentValidation;

namespace Api.Validators;

public class UpdateTaskStatusValidator :  AbstractValidator<UpdateTaskDto>
{
    public UpdateTaskStatusValidator()
    {
        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("O status é obrigatório.")
            .Must(status => status == "Pendente" || status == "Concluído")
            .WithMessage("O status deve ser 'Pendente' ou 'Concluído'.");
    }

}