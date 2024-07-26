using Pedidos.Contrato.Modelos.ViewModel;
using Modelo = Pedidos.Contrato.Modelos;

namespace Pedido.WebAPITeste.Extensoes
{    
    public static class ExtesoesPedido
    {
        public static Modelo.Pedido GetObjetoPedido()
        {
            return new Modelo.Pedido
            {
                IdPedido = 2,
                Nome = "Pedido 2",
                DtCriacao = DateTime.Now,
                Pago = true,
                DtAtualizacao = DateTime.Now,
                Produtos = new List<Modelo.Produto>
            {
                new Modelo.Produto
                {
                    IdProduto = 1,
                    PedidoId = 1,
                    DtCriacao = DateTime.Now,
                    Nome = "Produto 01",
                    Quantidade = 1,
                    Valor = 10
                },
                new Modelo.Produto
                {
                    IdProduto = 2,
                    PedidoId = 1,
                    DtCriacao = DateTime.Now,
                    Nome = "Produto 02",
                    Quantidade = 2,
                    Valor = 10
                }
            }
            };
        }

        public static List<Modelo.Pedido> GetObjetListPedido()
        {
            return new List<Modelo.Pedido>
            {
                    new Modelo.Pedido
                    {
                        IdPedido = 1,
                        Nome = "Pedido 1",
                        DtCriacao = DateTime.Now,
                        Pago = false,
                        Produtos = new List<Modelo.Produto>
                        {
                            new Modelo.Produto
                            {
                                IdProduto = 1,
                                PedidoId = 1,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 01",
                                Quantidade = 1,
                                Valor = 10
                            },
                            new Modelo.Produto
                            {
                                IdProduto = 2,
                                PedidoId = 1,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 02",
                                Quantidade = 2,
                                Valor = 10
                            }
                        }
                    },
                    new Modelo.Pedido
                    {
                        IdPedido = 2,
                        Nome = "Pedido 2",
                        DtCriacao = DateTime.Now,
                        Pago = true,
                        DtAtualizacao = DateTime.Now,
                        Produtos = new List<Modelo.Produto>
                        {
                            new Modelo.Produto
                            {
                                IdProduto = 1,
                                PedidoId = 1,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 01",
                                Quantidade = 1,
                                Valor = 10
                            },
                            new Modelo.Produto
                            {
                                IdProduto = 2,
                                PedidoId = 1,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 02",
                                Quantidade = 2,
                                Valor = 10
                            }
                        }
                    }
            };
        }

        public static List<PedidoViewModel> GetObjetListPedidoView()
        {
            return new List<PedidoViewModel>
            {
                new PedidoViewModel
                {
                        PedidoId = 1,
                        Nome = "Pedido 1",
                        DtCriacao = DateTime.Now,
                        Pago = false,
                        Produtos = new List<ProdutoViewModel>
                        {
                            new ProdutoViewModel
                            {
                                ProdutoId = 1,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 01",
                                Quantidate = 1,
                                Valor = 10
                            },
                            new ProdutoViewModel
                            {
                                ProdutoId = 2,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 02",
                                Quantidate = 2,
                                Valor = 10
                            }
                        }
                },
                new PedidoViewModel
                {
                        PedidoId = 2,
                        Nome = "Pedido 2",
                        DtCriacao = DateTime.Now,
                        Pago = true,
                        Produtos = new List<ProdutoViewModel>
                        {
                            new ProdutoViewModel
                            {
                                ProdutoId = 1,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 01",
                                Quantidate = 1,
                                Valor = 10
                            },
                            new ProdutoViewModel
                            {
                                ProdutoId = 2,
                                DtCriacao = DateTime.Now,
                                Nome = "Produto 02",
                                Quantidate = 2,
                                Valor = 10
                            }
                        }
                }
            };
        }
    }
}
