using AutoMapper;
using Pedidos.Contrato.Modelos;
using Pedidos.Contrato.Modelos.Dto;
using Pedidos.Contrato.Modelos.ViewModel;

namespace Pedidos.Infraestrutura.Mapeamentos
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pedido, PedidoDto>();
            CreateMap<PedidoDto, Pedido>();
            CreateMap<Produto, ProdutoDto>();
            CreateMap<ProdutoDto, Produto>();
            CreateMap<Pedido, PedidoViewModel>()
            .ForMember(dest => dest.DtCriacao, opt => opt.MapFrom(src => src.DtCriacao))
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
            .ForMember(dest => dest.DtPagamento, opt => opt.MapFrom(src => src.DtPagamento))
            .ForMember(dest => dest.Pago, opt => opt.MapFrom(src => src.Pago))
            .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.Produtos))
            .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => src.IdPedido));
            CreateMap<Produto, ProdutoViewModel>()
           .ForMember(dest => dest.DtCriacao, opt => opt.MapFrom(src => src.DtCriacao))
           .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
           .ForMember(dest => dest.Quantidate, opt => opt.MapFrom(src => src.Quantidade))
           .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor))
           .ForMember(dest => dest.ProdutoId, opt => opt.MapFrom(src => src.IdProduto));
        }
    }
}
