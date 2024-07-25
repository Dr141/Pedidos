namespace Pedidos.Dominio.Modelos.ViewModel
{
    public class ProdutoViewModel
    {
        public int ProdutoId { get; set; }
        public DateTime? DtCriacao { get; set; } = DateTime.Now;

        public string? Nome { get; set; }

        public int Quantidate { get; set; }

        public decimal Valor { get; set; }
    }
}
