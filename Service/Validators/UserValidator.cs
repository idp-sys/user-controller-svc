using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Domain.Entities;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x => { throw new ArgumentNullException($"Não foi possível encontrar o objeto"); });

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("É necessário informar o nome.")
                .NotNull().WithMessage("É necessário informar o nome.");

            List<string> statusConditions = new List<string> {"active", "inactive"};
            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("É necessário informar o status.")
                .NotNull().WithMessage("É necessário informar o status.")
                .Must(x => statusConditions.Contains(x.ToLowerInvariant()))
                .WithMessage("Valores válidos: 'active' ou 'inactive'.");
        }
    }
}
