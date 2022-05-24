using Cadastro_de_Contatos.Models;
using Cadastro_de_Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro_de_Contatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatosController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;

        }



        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);

        }

        public IActionResult Editar(int Id)
        {
            Contatomodel contato = _contatoRepositorio.ListarPorId(Id);
            return View(contato);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            Contatomodel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int Id)
        {
            try
            {
                _contatoRepositorio.Apagar(Id);
                TempData["MensagemSucesso"] = "Contato Apagado Com Sucesso";
                return RedirectToAction("Index");
                
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro Inesperado erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Adicionar(Contatomodel contato)
        {
            try
            {
                if (ModelState.IsValid)

                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato Cadastrado Com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Erro Inesperado erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
              


        }

        [HttpPost]
        public IActionResult Editar(Contatomodel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato Alterado Com Sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch(Exception erro)
            {
                TempData["MensagemErro"] = $"Erro Inesperado erro: {erro.Message} ";
                return RedirectToAction("Index");
            }



        }
    }

}
