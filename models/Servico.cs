using System.ComponentModel.DataAnnotations;

namespace ProvaCSharp.Models
{
    public class Servico
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do serviço é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preço do serviço é obrigatório.")]
        public decimal Preco { get; set; }

        public bool Status { get; set; } = true;
    }
}