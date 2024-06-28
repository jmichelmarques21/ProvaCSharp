using System.ComponentModel.DataAnnotations;

namespace ProvaCSharp.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do cliente é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não é válido.")]
        public string Email { get; set; }

    }
}