using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository.CategoriaRepo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.CategoriaServices
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }
        
        public async Task AdicionarCategoria(Categoria categoria)
        {
            await _categoriaRepository.InsereCategoria(categoria);
        }

        public async Task<Categoria> RetornaCategoria(Guid guidId)
        {
            return await _categoriaRepository.RetornaCategoria(guidId);
        }

        public async Task<List<Categoria>> RetornaCategorias()
        {
            return await _categoriaRepository.RetornaCategorias();
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            await _categoriaRepository.AtualizaCategoria(categoria);
        }

        public async Task<Guid> DeletarCategoria(Guid guidId)
        {
            return await _categoriaRepository.DeletaCategoria(guidId);
        }
    }
}
