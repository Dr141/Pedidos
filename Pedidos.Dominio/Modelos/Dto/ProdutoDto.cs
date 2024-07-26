using System.ComponentModel.DataAnnotations;

namespace Pedidos.Contrato.Modelos.Dto
{
    public class ProdutoDto
    {
        [Required]
        public string? Nome { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}
