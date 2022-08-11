﻿using System.ComponentModel.DataAnnotations;

namespace NovoProjeto.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
