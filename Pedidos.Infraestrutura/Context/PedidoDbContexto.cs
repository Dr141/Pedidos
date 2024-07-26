using Microsoft.EntityFrameworkCore;
using Pedidos.Contrato.Modelos;

namespace Pedidos.Infraestrutura.Context
{
    public class PedidoDbContexto : DbContext
    {
        public PedidoDbContexto(DbContextOptions<PedidoDbContexto> options) : base(options) { }

        public PedidoDbContexto() { }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                        .HasOne<Pedido>(pe => pe.Pedido)
                        .WithMany(pr => pr.Produtos)
                        .HasForeignKey(pe => pe.PedidoId);
        }
    }
}
