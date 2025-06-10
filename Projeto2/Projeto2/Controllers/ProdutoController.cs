using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;
using Projeto2.Repository;

namespace Projeto2.Controllers
{
    public class ProdutoController : Controller
    {
        /* Declarando uma variável privada somente para leitura do  tipo UsuarioRepository chamada _usuarioRepository */

        private readonly ProdutoRepository _produtoRepository;
        /* Definindo o construtor da classe UsuarioController que vao receber uma instância de UsuarioRepository */

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public IActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _produtoRepository.CadastrarProduto(produto);

                return RedirectToAction("Index", "Home");
            }

            return View(produto);
        }
    }
}
