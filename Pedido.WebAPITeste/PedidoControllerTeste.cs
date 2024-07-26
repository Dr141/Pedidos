using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Pedidos.API.Controllers;
using Pedidos.Contrato.Modelos.Dto;
using Pedidos.Contrato.Modelos.ViewModel;
using Pedidos.Infraestrutura.Interfaces;
using Pedidos.Infraestrutura.Negocios;
using Modelo = Pedidos.Contrato.Modelos;

namespace Pedido.WebAPITeste
{
    public class PedidoControllerTeste
    {
        private readonly Mock<IPedidoRepository> _mockPedidoRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PedidoBll _pedidoBll;
        private readonly PedidoController _controller;
        public PedidoControllerTeste()
        {
            _mockPedidoRepository = new Mock<IPedidoRepository>();
            _mockMapper = new Mock<IMapper>();
            _pedidoBll = new PedidoBll(_mockPedidoRepository.Object, _mockMapper.Object);
            _controller = new PedidoController(_pedidoBll);
        }

        [Fact]
        public async void postTest()
        {
            var expectedId = 1;
            _mockPedidoRepository.Setup(repo => repo.AdicionarPedido(It.IsAny<Modelo.Pedido>()))
                                 .ReturnsAsync(expectedId);

            var retorno = await _controller.Post("Novo Pedido");
            var okResult = Assert.IsType<OkObjectResult>(retorno.Result);
            var value = Assert.IsType<string>(okResult.Value);
            Assert.StartsWith("PedidoId:", value);
            Assert.Contains(expectedId.ToString(), value);
        }

        [Fact]
        public async void GetTest()
        {
            var pedidoViewModels = Extensoes.ExtesoesPedido.GetObjetListPedidoView();
            _mockPedidoRepository.Setup(repo => repo.ObterTodos())
                                 .ReturnsAsync(Extensoes.ExtesoesPedido.GetObjetListPedido());
            
            _mockMapper.Setup(m => m.Map<PedidoViewModel>(It.IsAny<Modelo.Pedido>()))
                   .Returns((Modelo.Pedido p) => pedidoViewModels.Find(vm => vm.PedidoId == p.IdPedido));
            var retorno = await _controller.Get();
            var resultValue = Assert.IsAssignableFrom<IEnumerable<PedidoViewModel>>(retorno);
            Assert.Equal(pedidoViewModels.Count, resultValue.Count());
        }

        [Fact]
        public async void GetIdTeste()
        {
            var pedidoViewModels = Extensoes.ExtesoesPedido.GetObjetListPedidoView();
            _mockPedidoRepository.Setup(repo => repo.ObertePorId(2))
                                 .ReturnsAsync(Extensoes.ExtesoesPedido.GetObjetoPedido());

            _mockMapper.Setup(m => m.Map<PedidoViewModel>(It.IsAny<Modelo.Pedido>()))
                       .Returns((Modelo.Pedido p) => pedidoViewModels.Find(vm => vm.PedidoId == p.IdPedido));
            var retorno = await _controller.Get(2);
            var resultValue = Assert.IsAssignableFrom<PedidoViewModel>(retorno);
            Assert.Equal(retorno, pedidoViewModels.FirstOrDefault(p => p.PedidoId.Equals(2)));
        }

        [Fact]
        public async void PutTest()
        {
            var pedidoViewModels = Extensoes.ExtesoesPedido.GetObjetListPedidoView();
            _mockPedidoRepository.Setup(repo => repo.ObertePorId(2))
                                 .ReturnsAsync(Extensoes.ExtesoesPedido.GetObjetoPedido());

            _mockMapper.Setup(m => m.Map<PedidoViewModel>(It.IsAny<Modelo.Pedido>()))
                       .Returns((Modelo.Pedido p) => pedidoViewModels.Find(vm => vm.PedidoId == p.IdPedido));

            _mockPedidoRepository.Setup(repo => repo.Atualizar(It.IsAny<Modelo.Pedido>()));

            var retorno = await _controller.Put(2, new PedidoDto
            {
                Nome = "Rexona",
                Pago = false
            });
            var okResult = Assert.IsType<OkObjectResult>(retorno.Result);
            var value = Assert.IsType<string>(okResult.Value);
            Assert.StartsWith("Pedido atualizado.", value);
        }
    }
}
