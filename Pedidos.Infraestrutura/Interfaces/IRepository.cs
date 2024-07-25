namespace Pedidos.Infraestrutura.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        public ValueTask<TEntity> GetByIdAsync(int id);

        public Task<List<TEntity>> GetAllAsync();
        
        public Task AddAsync(TEntity entity);

        public void Remove(TEntity entity);

        public void RemoveRage(List<TEntity> entities);

        public void Update(TEntity entity);

        public void UpdateRage(List<TEntity> entities);
    }
}
