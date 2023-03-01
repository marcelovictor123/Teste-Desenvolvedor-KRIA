using CatalogoDeProjetos.Models;
using CatalogoDeProjetos.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoDeProjetos.Controllers
{
    public class RepositoriosController : Controller
    {
        private readonly IRepository _repositorio;

        public IActionResult Detalhes(int id)
        {
            RepositoriosModel repositorio = _repositorio.ListarPorId(id);
            return View(repositorio);
        }


        public RepositoriosController(IRepository repositorio)
        {
            _repositorio = repositorio;
        }
        public IActionResult Index()
        {
            List<RepositoriosModel> repositorio = _repositorio.BuscarTodos();
            return View(repositorio);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            RepositoriosModel repositorio = _repositorio.ListarPorId(id);
            return View(repositorio);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            _repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public IActionResult Apagar(int id)
        {
            

            RepositoriosModel repositorio = _repositorio.ListarPorId(id);
            return View(repositorio);
        }

        public IActionResult ApagarTodos()
        {
            _repositorio.ExcluirTodos();
            TempData["MensagemSucesso"] = "Todos os repositórios foram excluídos.";
            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult Criar(RepositoriosModel repositorio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.Adicionar(repositorio);
                    //   TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                // }*/

                return View(repositorio);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, erro ao cadastrar contato. Erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(RepositoriosModel repositorio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio.Atualizar(repositorio);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", repositorio);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, erro ao editar contato. Erro:{erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Favoritar(int id)
        {
            RepositoriosModel repositorio = _repositorio.ListarPorId(id);
            repositorio.Favorito = true;
            _repositorio.Atualizar(repositorio);
            return RedirectToAction("Detalhes", new { id = id });
        }

        public IActionResult Desfavoritar(int id)
        {
            RepositoriosModel repositorio = _repositorio.ListarPorId(id);
            repositorio.Favorito = false;
            _repositorio.Atualizar(repositorio);
            return RedirectToAction("Detalhes", new { id = id });
        }

        public IActionResult Favoritos()
        {
            List<RepositoriosModel> repositoriosFavoritos = _repositorio.BuscarTodos().Where(r => r.Favorito).ToList();
            return View("Index", repositoriosFavoritos);
        }
    }
  


}


