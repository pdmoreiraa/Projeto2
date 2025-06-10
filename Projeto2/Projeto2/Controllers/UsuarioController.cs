using Microsoft.AspNetCore.Mvc;
using Projeto2.Models;
using Projeto2.Repository;

namespace Projeto2.Controllers
{
    public class UsuarioController : Controller
    {
        
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            // Verifica se o ModelState é válido. O ModelState é considerado válido se não houver erros de validação.
            if (ModelState.IsValid)
            {
                _usuarioRepository.AddUsuario(usuario);
                
                return RedirectToAction("Login");
            }
      
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepository.ObterUsuario(email);

            if (usuario != null && usuario.Senha == senha)
            {
                
                return RedirectToAction("Cliente", "Cliente");
            }
             
            ModelState.AddModelError("", "Email ou senha inválidos.");
            
            return View();
        }
    }
}
