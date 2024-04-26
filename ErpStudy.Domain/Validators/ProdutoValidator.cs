namespace ErpStudy.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            When(produto => produto is null, ()
                    => RuleFor(produto => produto).NotNull())
                .Otherwise(() => RuleFor(produto => produto.ProdutoID).NotEmpty());
        }
    }
}