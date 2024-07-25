namespace Pedidos.Dominio.Modelos.ViewModel
{
    public class PedidoViewModel
    {
        public DateTime DtCriacao { get; set; } = DateTime.Now;

        public string? Nome { get; set; }

        public DateTime? DtPagamento { get; set; }

        public bool Pago { get; set; }

        public ICollection<ProdutoViewModel>? Produtos { get; set; }
    }
}
