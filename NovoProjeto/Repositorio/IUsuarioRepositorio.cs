using NovoProjeto.Models;
using System.Collections.Generic;

namespace NovoProjeto.Repositorio
{
    public interface IUsuarioRepositorio {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmailELogin(string email,string login );
        UsuarioModel BuscarPorID(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenhaModel);
        bool Apagar(int id);
    }
}
