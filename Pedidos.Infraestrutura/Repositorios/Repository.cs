using Microsoft.EntityFrameworkCore;
using Pedidos.Infraestrutura.Context;
using Pedidos.Infraestrutura.Interfaces;

namespace Pedidos.Infraestrutura.Repositorios
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly PedidoDbContexto Contexto;

        public Repository(PedidoDbContexto pPedidoContexto)
        {
            Contexto = pPedidoContexto;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Contexto.Set<TEntity>().AddAsync(entity);
            await Contexto.SaveChangesAsync();
        }

        public void Remove(TEntity entity)
        {
            Contexto.Set<TEntity>().Remove(entity);
            Contexto?.SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await Contexto.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await Contexto.Set<TEntity>().FindAsync(id);
        }

        public void RemoveRage(List<TEntity> entities)
        {
            Contexto.Set<TEntity>().RemoveRange(entities);
            Contexto?.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Contexto.Set<TEntity>().Update(entity);
            Contexto?.SaveChanges();
        }

        public void UpdateRage(List<TEntity> entities)
        {
            Contexto.Set<TEntity>().UpdateRange(entities);
            Contexto?.SaveChanges();
        }
    }
}
