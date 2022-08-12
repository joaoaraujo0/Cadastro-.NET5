using ControleDeContatos.Models;
using System.Collections.Generic;

namespace NovoProjeto.Repositorio {
    public interface IContatoRepositorio {
        ContatoModel ListarPorId(int id);
        List<ContatoModel> BuscarTodos( int usuarioId);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
