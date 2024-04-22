using ErpStudyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Repository.ProdutoRepo
{
    public interface IProdutoRepository
    {
        Task InsereProduto(Produto produto);
        Task<List<Produto>> RetornaTodosProdutos();
        Task<Produto> RetornaProduto(Guid produtoGuid);
        Task<Produto> AtualizarProduto(Produto produto);
        Task<Produto> DeletarProduto(Produto produto);
    }
}