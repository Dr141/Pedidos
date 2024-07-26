using Pedidos.Contrato.Modelos.Dto;
using Pedidos.Contrato.Modelos;
using Pedidos.Infraestrutura.Interfaces;
using AutoMapper;

namespace Pedidos.Infraestrutura.Negocios
{
    public class ProtudoBll
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly PedidoBll _pedidoBll;
        public ProtudoBll(IProdutoRepository produtoRepository, IMapper mapper, PedidoBll pedidoBll)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _pedidoBll = pedidoBll;
        }

        public async Task<int> AdicionarProduto(int pIdPedido, ProdutoDto pProdutoDto)
        {
            Pedido pedido = await _pedidoBll.ObterPorId(pIdPedido);

            if (pedido is Pedido && pedido.DtPagamento is null)
            {
                Produto produto = _mapper.Map<Produto>(pProdutoDto);
                produto.PedidoId = pIdPedido;

                return await _produtoRepository.AdicionarProduto(produto); ;
            }

            throw new InvalidOperationException($"O pedido com ID {pIdPedido}, encontra-se fechado na data {pedido.DtPagamento?.ToString("dd/MM/yyyy")}.");             
        }

        public async Task<Produto> ObterProdutoPorId(int pId)
        {
            return await _produtoRepository.ObertePorId(pId);
        }

        public async Task AtualizarProduto(int pIdPedido, int pIdProduto, ProdutoDto produtoDto)
        {
            var pedido = await _pedidoBll.ObterPorId(pIdPedido);

            if(pedido is Pedido && pedido.DtPagamento is null)
            {
                Produto produto = _mapper.Map<Produto>(produtoDto);
                produto.IdProduto = pIdProduto;
                produto.DtAtualizacao = DateTime.Now;
                _produtoRepository.Atualizar(produto);
            }            

            throw new InvalidOperationException($"O pedido com ID {pIdPedido}, encontra-se fechado na data {pedido.DtPagamento?.ToString("dd/MM/yyyy")}.");
        }

        public async Task RemoverProduto(int pId) 
        {

            Produto produto = await _produtoRepository.ObertePorId(pId);

            if(produto is Produto && produto.Pedido.DtPagamento is null)
            {
                _produtoRepository.Deleta(produto);
                return;
            }
            
            throw new InvalidOperationException($"O pedido com ID {produto.IdProduto}, encontra-se fechado na data {produto.Pedido.DtPagamento?.ToString("dd/MM/yyyy")}.");
        }
    }
}
