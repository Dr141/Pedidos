using Microsoft.EntityFrameworkCore;
using Pedidos.Dominio.Modelos;
using Pedidos.Infraestrutura.Context;
using Pedidos.Infraestrutura.Interfaces;

namespace Pedidos.Infraestrutura.Repositorios
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(PedidoDbContexto pPedidoContexto) : base(pPedidoContexto)
        {
        }

        public async Task AdicionarProduto(Produto produto)
        {
            await AddAsync(produto);
        }

        public void Atualizar(Produto produto)
        {
            Update(produto);
        }

        public void AtualizarTodos(List<Produto> produtos)
        {            
            UpdateRage(produtos);
        }

        public void Deleta(Produto produto)
        {
            Remove(produto);
        }

        public void DeletaTodos(List<Produto> produtos)
        {
            RemoveRage(produtos);
        }

        public async Task<Produto> ObertePorId(int id)
        {
            return await Contexto.Produtos.Include(pr => pr.Pedido)
                                 .FirstOrDefaultAsync(pr => pr.IdProduto == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await GetAllAsync();
        }
    }
}
