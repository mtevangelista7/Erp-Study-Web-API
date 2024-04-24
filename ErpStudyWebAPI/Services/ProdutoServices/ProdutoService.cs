using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository.ProdutoRepo;
using System;
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
        public async Task<Produto> AdicionarProduto(Produto produto)
        {
            Guid guidProduto = await _produtoRepository.InsereProduto(produto);
            
            // Caso tenha adicionado o produto com sucesso
            if (guidProduto != Guid.Empty)
            {
                // retorna o produto atualizado
                return await RetornarProduto(guidProduto);
            }
            
            // Caso não tenha conseguido adicionar retorna null
            return null;
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
        /// Retorna um produto pelo id
        /// </summary>
        /// <param name="guidProduto"></param>
        /// <returns></returns>
        public async Task<Produto> RetornarProduto(Guid guidProduto)
        {
            return await _produtoRepository.RetornaProduto(guidProduto);
        }

        /// <summary>
        /// Atualiza um produto 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public async Task<bool> AtualizarProduto(Produto produto)
        {
            return await _produtoRepository.AtualizarProduto(produto);
        }

        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="guidProduto"></param>
        /// <returns></returns>
        public async Task<bool> DeletarProduto(Guid guidProduto)
        {
            return await _produtoRepository.DeletarProduto(guidProduto);
        }
    }
}
