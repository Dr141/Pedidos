using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Modelos;
using Pedidos.Infraestrutura.Context;
using Pedidos.Infraestrutura.Interfaces;

namespace Pedidos.Infraestrutura.Repositorios
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(PedidoDbContexto pPedidoContexto) : base(pPedidoContexto)
        {
        }

        public async Task<int> AdicionarPedido(Pedido pedido)
        {
           await AddAsync(pedido);
            return pedido.IdPedido; 
        }

        public void Atualizar(Pedido pedido)
        {
            Update(pedido);
        }

        public async Task<Pedido> ObertePorId(int id)
        {
            return await Contexto.Pedidos.Include(pe => pe.Produtos)
                                 .FirstOrDefaultAsync(pe => pe.IdPedido == id);
        }

        public async Task<List<Pedido>> ObterTodos()
        {
            return await GetAllAsync();
        }
    }
}
