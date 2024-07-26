using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Pedidos.Contrato.Modelos
{
    public class Pedido
    {
        [JsonIgnore]
        [Key]
        public int IdPedido { get; set; }
                
        public DateTime DtCriacao { get; set; } = DateTime.Now;

        public DateTime? DtAtualizacao { get; set; } = null;

        [Length(1, 100)]
        public string Nome { get; set; }
        
        public DateTime? DtPagamento { get; set; }

        public bool Pago { get; set; }

        public ICollection<Produto>? Produtos { get; set; }
    }
}
