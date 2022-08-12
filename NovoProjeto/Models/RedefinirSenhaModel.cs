using System.ComponentModel.DataAnnotations;

namespace NovoProjeto.Models
{
    public class RedefinirSenhaModel
    {
            [Required(ErrorMessage = "Digite o Login")]
            public string Login { get; set; }
            [Required(ErrorMessage = "Digite a e-mail")]
            public string Email { get; set; }
        
    }

}
