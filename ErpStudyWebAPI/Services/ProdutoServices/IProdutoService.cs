using ErpStudyWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.ProdutoServices {
    public interface IProdutoService {
        Task AdicionarProduto(Produto produto);
        Task<List<Produto>> RetornarProdutos();
        Task<Produto> AtualizarProduto(Produto produto);
        Task<Produto> DeletarProduto(Produto produto);
    }
}