using Cadastro_de_Contatos.Models;
using Cadastro_de_Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_Contatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio UsuariooRepositorio)
        {
            _usuarioRepositorio = UsuariooRepositorio;

        }

        public IActionResult Index()
        {
            var usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuarios = _usuarioRepositorio.ListarPorId(id);
            return View(usuarios);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuarios = _usuarioRepositorio.ListarPorId(id);
            return View(usuarios);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                _usuarioRepositorio.Apagar(id);
                TempData["MensagemSucesso"] = "Usuario Apagado Com Sucesso";
                return RedirectToAction("Index");
                
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro Inesperado erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuarios)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    _usuarioRepositorio.Adicionar(usuarios);
                    TempData["MensagemSucesso"] = "Usuario Cadastrado Com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuarios);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro Inesperado erro: {erro.Message} ";
                return RedirectToAction("Index");
            }



        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuarios)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuarios);
                    TempData["MensagemSucesso"] = "Contato Alterado Com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuarios);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro Inesperado erro: {erro.Message} ";
                return RedirectToAction("Index");
            }








        }

        }
    }
