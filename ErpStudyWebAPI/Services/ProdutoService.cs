using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository;
using ErpStudyWebAPI.Utilities;
using System;

namespace ErpStudyWebAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        public void AdicionarProduto(Produto produto)
        {
            // Chama o repositório para adicionar o produto
            ProdutoRepository produtoRepository = new ProdutoRepository(Util.StringConexao);

            produtoRepository.InsereProduto(produto);
        }
    }
}
