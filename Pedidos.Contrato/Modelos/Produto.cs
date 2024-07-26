using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.Contrato.Modelos
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }

        public DateTime DtCriacao { get; set; } = DateTime.Now;

        public DateTime? DtAtualizacao { get; set; } = null;

        public Pedido Pedido { get; set; }

        [ForeignKey(nameof(Pedido.IdPedido))]
        public int PedidoId { get; set; }

        [Length(1, 100)]
        public string Nome { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(14,2)")]
        public decimal Valor { get; set; }
    }
}
