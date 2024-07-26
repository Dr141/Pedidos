using Pedidos.Contrato.Modelos;

namespace Pedidos.Infraestrutura.Interfaces
{
    public interface IPedidoRepository
    {
        Task<int> AdicionarPedido(Pedido pedido);

        Task<List<Pedido>> ObterTodos();

        Task<Pedido> ObertePorId(int id);

        void Atualizar(Pedido pedido);
    }
}
