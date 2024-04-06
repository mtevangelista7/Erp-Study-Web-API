using ErpStudyWebAPI.Models.Enums;
using System;

namespace ErpStudyWebAPI.Models
{
    public class Produto
    {
        public Guid ProdutoID { get; set; }
        public string Nome { get; set; }
        public string CodigoSKU { get; set; }
        public double PrecoVenda { get; set; }
        public Unidade Unidade { get; set; }
        public Condicao Condicao { get; set; }
        public Categoria Categoria { get; set; }
    }
}
