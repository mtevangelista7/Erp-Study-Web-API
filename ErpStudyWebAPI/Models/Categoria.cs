using FluentValidation;
using System;

namespace ErpStudyWebAPI.Models
{
    public class Categoria
    {
        public Guid CategoriaID { get; set; }
        public string Nome { get; set; }
    }

    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        public CategoriaValidator()
        {
            // Quando a categoria for nula, aplica a regra não pode ser nula, caso não seja nula, aplica a regra
            // o nome não pode ser nulo
            When(categoria => categoria is null, () =>
                    RuleFor(categoria => categoria).NotNull())
                .Otherwise(() =>
                    RuleFor(categoria => categoria.Nome).NotNull().NotEmpty());
        }
    }
}