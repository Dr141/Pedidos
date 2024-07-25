using Pedidos.Dominio.Modelos;

namespace Pedidos.Infraestrutura.Interfaces
{
    public interface IProdutoRepository
    {
        Task AdicionarProduto(Produto produto);

        Task<IEnumerable<Produto>> ObterTodos();

        Task<Produto> ObertePorId(int id);

        void Deleta(Produto produto);

        void DeletaTodos(List<Produto> produtos);

        void Atualizar(Produto produto);

        void AtualizarTodos(List<Produto> produtos);
    }
}
