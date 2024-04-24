using ErpStudyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.ProdutoRepo
{
    public interface IProdutoRepository
    {
        Task<Guid> InsereProduto(Produto produto);
        Task<List<Produto>> RetornaTodosProdutos();
        Task<Produto> RetornaProduto(Guid produtoGuid);
        Task<bool> AtualizarProduto(Produto produto);
        Task<bool> DeletarProduto(Guid guidProduto);
    }
}