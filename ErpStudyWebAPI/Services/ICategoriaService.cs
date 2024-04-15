using ErpStudyWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ErpStudyWebAPI.Services {
    public interface ICategoriaService {
        public Task AdicionarCategoria(Categoria categoria);
        public Task<Categoria> RetornaCategoria(Guid guidId);
        public Task<List<Categoria>> RetornaCategorias();
        public Task AtualizarCategoria(Categoria categoria);
        public Task DeletarCategoria(Guid guidId);
    }
}