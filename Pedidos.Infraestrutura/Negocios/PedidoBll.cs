using AutoMapper;
using Pedidos.Dominio.Modelos;
using Pedidos.Dominio.Modelos.Dto;
using Pedidos.Dominio.Modelos.ViewModel;
using Pedidos.Infraestrutura.Interfaces;

namespace Pedidos.Infraestrutura.Negocios
{
    public class PedidoBll
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoBll(IPedidoRepository pedidoRepository, IMapper mapper) 
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<int> Adicionar(string pNome)
        {
            Pedido pedido = new Pedido { Nome = pNome };
            return await _pedidoRepository.AdicionarPedido(pedido); ;
        }

        public async Task<IEnumerable<Pedido>> ObterTodosPedidos()
        {
            return await _pedidoRepository.ObterTodos();
        }

        public async Task<PedidoViewModel> ObterPedidoPorId(int pId)
        {
            return _mapper.Map<PedidoViewModel>(await  _pedidoRepository.ObertePorId(pId));
        }

        public async Task<Pedido> ObterPorId(int pId)
        {
            return await _pedidoRepository.ObertePorId(pId);
        }

        public async Task AtualizarPedido(int pId, PedidoDto pedidoDto) 
        {
            var pedido = await _pedidoRepository.ObertePorId(pId);

            if(pedido.DtPagamento is null)
            {
                if (!string.IsNullOrEmpty(pedidoDto.Nome)) pedido.Nome = pedidoDto.Nome;

                if (pedido.Pago) pedido.DtPagamento = DateTime.Now;

                pedido.DtAtualizacao = DateTime.Now;
                _pedidoRepository.Atualizar(pedido);
                return;
            }            

            throw new InvalidOperationException($"O pedido com ID {pId}, encontra-se fechado na data {pedido.DtPagamento?.ToString("dd/MM/yyyy")}.");
        }
    }
}
