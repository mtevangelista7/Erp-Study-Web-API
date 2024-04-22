using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository.ProdutoRepo;
using System.Collections.Generic;
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
        
        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto"></param>
        public async Task AdicionarProduto(Produto produto)
        {
            await _produtoRepository.InsereProduto(produto);
        }

        /// <summary>
        /// Retonar todos os produtos
        /// </summary>
        /// <returns></returns>
        public async Task<List<Produto>> RetornarProdutos()
        {
            return await _produtoRepository.RetornaTodosProdutos();
        }

        /// <summary>
        /// Atualiza um produto 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            return await _produtoRepository.AtualizarProduto(produto);
        }

        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public async Task<Produto> DeletarProduto(Produto produto)
        {
            return await _produtoRepository.DeletarProduto(produto);
        }
    }
}
