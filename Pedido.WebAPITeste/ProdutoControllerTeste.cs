using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pedidos.API.Controllers;
using Pedidos.Contrato.Modelos;
using Pedidos.Contrato.Modelos.Dto;
using Pedidos.Contrato.Modelos.ViewModel;
using Pedidos.Infraestrutura.Interfaces;
using Pedidos.Infraestrutura.Negocios;
using Modelo = Pedidos.Contrato.Modelos;

namespace Pedido.WebAPITeste
{
    public class ProdutoControllerTeste
    {
        private readonly Mock<IPedidoRepository> _mockPedidoRepository;
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PedidoBll _pedidoBll;
        private readonly ProtudoBll _produtoBll;
        private readonly ProdutoController _controller;
        public ProdutoControllerTeste() 
        {
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            _mockPedidoRepository = new Mock<IPedidoRepository>();
            _mockMapper = new Mock<IMapper>();
            _pedidoBll = new PedidoBll(_mockPedidoRepository.Object, _mockMapper.Object);
            _produtoBll = new ProtudoBll(_mockProdutoRepository.Object, _mockMapper.Object, _pedidoBll);
            _controller = new ProdutoController(_produtoBll);
        }

        [Fact]
        public async void Post()
        {
            var pedidoId = 1;
            var produtoDto = new ProdutoDto { Nome = "Produto Teste", Quantidade = 1, Valor = 100 };
            var produto = new Produto { IdProduto = 1, Nome = produtoDto.Nome, Quantidade = produtoDto.Quantidade, Valor = produtoDto.Valor, PedidoId = pedidoId };
            _mockPedidoRepository.Setup(b => b.ObertePorId(pedidoId))
                             .ReturnsAsync(Extensoes.ExtesoesPedido.GetObjetoPedido);

            _mockMapper.Setup(m => m.Map<Produto>(produtoDto)).Returns(produto);

            _mockProdutoRepository.Setup(r => r.AdicionarProduto(It.IsAny<Produto>()))
                                  .ReturnsAsync(1);

            var resultado = await _controller.Post(pedidoId, produtoDto);

            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
            Assert.Equal("Produto incluído com sucesso.", okResult.Value);
        }

        [Fact]
        public async void Delete()
        {
            var produtoId = 1;
            var produto = new Produto { IdProduto = produtoId, Pedido = new Modelo.Pedido { DtPagamento = null } };

            _mockProdutoRepository.Setup(r => r.ObertePorId(produtoId))
                                  .ReturnsAsync(produto);

            var resultado = await _controller.Delete(produtoId);

            var okResult = Assert.IsType<OkObjectResult>(resultado.Result);
            Assert.Equal("Produto removido com sucesso.", okResult.Value);
        }
    }
}
