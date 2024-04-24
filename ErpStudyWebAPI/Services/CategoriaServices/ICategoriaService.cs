using ErpStudyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services.CategoriaServices
{
    public interface ICategoriaService
    {
        public Task AdicionarCategoria(Categoria categoria);
        public Task<Categoria> RetornaCategoria(Guid guidId);
        public Task<List<Categoria>> RetornaCategorias();
        public Task<bool> AtualizarCategoria(Categoria categoria);
        public Task<bool> DeletarCategoria(Guid guidId);
    }
}