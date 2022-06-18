using FluentValidation;

namespace Application.Features.TypeMeasurementUnits.Commands.CreateTypeMeasurementUnitCommand
{
    public class CreateTypeMeasurementUnitCommandValidator : AbstractValidator<CreateTypeMeasurementUnitCommand>
    {
        public CreateTypeMeasurementUnitCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(100).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres");

            RuleFor(c => c.Description)
                .MaximumLength(100).WithMessage("{PropertyDescription} no puede tener mas de {MaxLength} caracteres");
        }
    }
}
