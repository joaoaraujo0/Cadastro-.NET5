using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Filters;
using NovoProjeto.Models;
using NovoProjeto.Repositorio;
using System.Collections.Generic;

namespace NovoProjeto.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }
        public IActionResult Criar()
        {
            return View();
        }
        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.BuscarPorID(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try {
                bool apagado = _usuarioRepositorio.Apagar(id);

                if (apagado) {
                    TempData["MensagemSucesso"] = "Usuario apagado com sucesso!";

                }
                else {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuario!";
                }
                return RedirectToAction("Index");

            }
            catch (System.Exception erro) {

                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuario, mais detalhes do erro:{erro.Message} ";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try {

                if (ModelState.IsValid) {
                     usuario = _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuario cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(usuario);

            }
            catch (System.Exception erro) {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuario, detalhe do erro:{erro.Message} ";
                return RedirectToAction("Index"); ;
            }
        }
        [HttpPost]
        public IActionResult Editar(UsuarioSemSenhaModel UsuarioSemSenhaModel)
        {
            try {
                UsuarioModel usuario = null;
                if (ModelState.IsValid) {
                    usuario = new UsuarioModel() {
                        Id = UsuarioSemSenhaModel.Id,
                        Nome=UsuarioSemSenhaModel.Nome,
                        Login = UsuarioSemSenhaModel.Login,
                        Email=UsuarioSemSenhaModel.Email,
                        Perfil=UsuarioSemSenhaModel.Perfil
                    };

                    usuario = _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = $"Usuário alterado com sucesso ";
                    return RedirectToAction("Index");
                }
                return View("Editar", usuario);

            }
            catch (System.Exception erro) {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuario, detalhe do erro:{erro.Message} ";
                return RedirectToAction("Index"); ;
            }
        }
    }
}
