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
        public Task AtualizarCategoria(Categoria categoria);
        public Task<Guid> DeletarCategoria(Guid guidId);
    }
}