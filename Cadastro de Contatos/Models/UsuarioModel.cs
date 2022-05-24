using Cadastro_de_Contatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cadastro_de_Contatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite Um Nome Valido")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite Um Login Valido")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite Um Email Valido")]
        [EmailAddress(ErrorMessage = "Email Invalido")]
        public string Email { get; set; }
        [Required]
        public PerfilEnum perfil { get; set; }
        [Required(ErrorMessage = "Digite Uma senha Valida")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }




    }
}
