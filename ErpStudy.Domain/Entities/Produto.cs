using ErpStudy.Domain.Enums;

namespace ErpStudy.Domain.Entities
{
    public class Produto
    {
        public Guid ProdutoID { get; set; }
        public string Nome { get; set; }
        public string CodigoSKU { get; set; }
        public double PrecoVenda { get; set; }
        public UnidadeMedida Unidade { get; set; }
        public CondicaoProduto Condicao { get; set; }
        public Categoria Categoria { get; set; }
    }
}