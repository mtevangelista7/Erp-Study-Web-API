using ErpStudyWebAPI.Models;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.ProdutoServices {
    public interface IProdutoService {
        Task AdicionarProduto(Produto produto);
    }
}