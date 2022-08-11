using Microsoft.AspNetCore.Mvc;
using NovoProjeto.Helper;
using NovoProjeto.Models;
using NovoProjeto.Repositorio;
using System;

namespace NovoProjeto.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;
        public LoginController(IUsuarioRepositorio usuarioRepositorio,
            ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            //Se o usuario estiver logado, redirecionar para a home

            if(_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index","Home");
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoUsuario();
            return RedirectToAction("Index","Login");    
        }


        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try {
                if (ModelState.IsValid) {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if (usuario != null) {
                        if (usuario.SenhaValida(loginModel.Senha)) {

                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index","Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
