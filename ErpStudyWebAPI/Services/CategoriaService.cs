using ErpStudyWebAPI.Models;
using ErpStudyWebAPI.Repository;
using ErpStudyWebAPI.Utilities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services
{
    public class CategoriaService
    {
        public async Task AdicionarCategoria(Categoria categoria)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(Util.StringConexao);

            await categoriaRepository.InsereCategoria(categoria);
        }

        public async Task<Categoria> RetornaCategoria(Guid guidId)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(Util.StringConexao);

            return await categoriaRepository.RetornaCategoria(guidId);
        }

        public async Task<List<Categoria>> RetornaCategorias()
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(Util.StringConexao);

            return await categoriaRepository.RetornaCategorias();
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(Util.StringConexao);

            await categoriaRepository.AtualizaCategoria(categoria);
        }

        public async Task DeletarCategoria(Guid guidId)
        {
            CategoriaRepository categoriaRepository = new CategoriaRepository(Util.StringConexao);

            await categoriaRepository.DeletaCategoria(guidId);
        }
    }
}
