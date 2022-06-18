using FluentValidation;

namespace Application.Features.TypeMeasurementUnits.Commands.UpdateTypeMeasurementUnitCommand
{
    public class UpdateTypeMeasurementUnitCommandValidator : AbstractValidator<UpdateTypeMeasurementUnitCommand>
    { 
        public UpdateTypeMeasurementUnitCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(100).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres");

            RuleFor(c => c.Description)
                .MaximumLength(100).WithMessage("{PropertyDescription} no puede tener mas de {MaxLength} caracteres");
        }
        
    }
}
