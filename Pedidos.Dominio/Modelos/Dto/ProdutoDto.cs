using System.ComponentModel.DataAnnotations;

namespace Pedidos.Dominio.Modelos.Dto
{
    public class ProdutoDto
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public int Quantidate { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
