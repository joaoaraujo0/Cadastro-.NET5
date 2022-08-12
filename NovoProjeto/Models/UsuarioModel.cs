using ControleDeContatos.Models;
using NovoProjeto.Enums;
using NovoProjeto.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovoProjeto.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuario")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuario")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuario")]
        public PerfilEnum? Perfil { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuario")]
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual List<ContatoModel> Contatos { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }
        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Senha = novaSenha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0,8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }
    }
}
