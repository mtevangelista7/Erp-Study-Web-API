using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository.ProdutoRepo;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.ProdutoServices
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        
        public async Task AdicionarProduto(Produto produto)
        {
            // Chama o repositório para adicionar o produto
            //ProdutoRepository produtoRepository = new ProdutoRepository(Util.StringConexao);
            await _produtoRepository.InsereProduto(produto);
        }
    }
}
