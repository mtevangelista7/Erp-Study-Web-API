using ErpStudyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.ProdutoServices {
    public interface IProdutoService {
        Task<Produto> AdicionarProduto(Produto produto);
        Task<List<Produto>> RetornarProdutos();
        Task<Produto> RetornarProduto(Guid guidProduto);
        Task<bool> AtualizarProduto(Produto produto);
        Task<bool> DeletarProduto(Guid guidProduto);
    }
}