using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_Contatos.Models
{
    public class Contatomodel
    {
        
        public int id { get; set; } 
        [Required (ErrorMessage = "Digite Um Nome Valido") ]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite Um Email Valido")]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string email { get; set; }
        [Required(ErrorMessage = "Digite Um Celular Valido")]
        [Phone(ErrorMessage ="Celular Invalido")]
        public string celular { get; set; }
        

    }
}
