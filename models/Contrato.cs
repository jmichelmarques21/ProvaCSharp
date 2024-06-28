using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaCSharp.Models
{
    public class Contrato
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O ID do serviço é obrigatório.")]
        public int ServicoId { get; set; }

        [Required(ErrorMessage = "O preço cobrado é obrigatório.")]
        public decimal PrecoCobrado { get; set; }

        public DateTime DataContratacao { get; set; } = DateTime.UtcNow;

    
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [ForeignKey("ServicoId")]
        public Servico Servico { get; set; }
    }
}