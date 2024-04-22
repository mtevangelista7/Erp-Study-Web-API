using FluentValidation;

namespace ErpStudyWebAPI.Models.DTOs
{
    public class UsuarioCadastroDto
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }

    public class UsuarioCadastroDTOValidator : AbstractValidator<UsuarioCadastroDto>
    {
        public UsuarioCadastroDTOValidator()
        {
            When(usuario => usuario is null, ()
                    => RuleFor(usuario => usuario).NotNull())
                .Otherwise(() =>
                    RuleFor(usuario => usuario.NomeUsuario).NotNull().NotEmpty().WithMessage("O nome é obrigatório"));
            RuleFor(usuario => usuario.Senha).NotNull().NotEmpty().WithMessage("A senha é obrigatória");
        }
    }
}