using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestrutura.Context;
using Pedidos.Infraestrutura.Interfaces;
using Pedidos.Infraestrutura.Mapeamentos;
using Pedidos.Infraestrutura.Negocios;
using Pedidos.Infraestrutura.Repositorios;

namespace Pedidos.API.Extensoes
{
    public static class CollectionExtensions
    {
        public static IServiceCollection RegistrarDependencias(this IServiceCollection services) 
        {
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<PedidoBll>();
            services.AddScoped<ProtudoBll>();
            return services;
        }

        public static void Migrations(this IServiceProvider services) 
        {
            services.CreateScope().ServiceProvider.GetRequiredService<PedidoDbContexto>()
            .Database.Migrate();
        }
    }
}
