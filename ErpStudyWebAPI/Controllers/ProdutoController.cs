using ErpStudyWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ErpStudyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService)
        {
            _logger = logger;
            _produtoService = produtoService;
        }
    }
}
