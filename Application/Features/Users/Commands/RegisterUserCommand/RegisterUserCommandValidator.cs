using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Users.Commands.RegisterUserCommand
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(50).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(50).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida.")
                .MaximumLength(50).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres.");

            RuleFor(p => p.UserName)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
               .MaximumLength(50).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres.");

            RuleFor(p => p.Password)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
               .MaximumLength(15).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres.");

            RuleFor(p => p.ConfirmPassword)
              .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
              .MaximumLength(15).WithMessage("{PropertyName} no puede tener mas de {MaxLength} caracteres.")
              .Equal(p => p.Password).WithMessage("{PropertyName} debe ser identica a password.");
        }
    }
}
