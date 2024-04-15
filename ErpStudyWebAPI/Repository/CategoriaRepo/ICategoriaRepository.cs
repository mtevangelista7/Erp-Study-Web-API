using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ErpStudyWebAPI.Models;

namespace ErpStudyWebAPI.Repository.CategoriaRepo
{
    public interface ICategoriaRepository
    {
        Task InsereCategoria(Categoria categoria);
        Task AtualizaCategoria(Categoria categoria);
        Task<Categoria> RetornaCategoria(Guid guidId);
        Task<List<Categoria>> RetornaCategorias();
        Task DeletaCategoria(Guid guidId);
    }
}