using Ardalis.Specification;

namespace DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task Insert(TEntity entity);
        void Update(TEntity entity);
        Task Delete(int id);

        Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification);
        Task<TEntity?> GetFirstBySpec(ISpecification<TEntity> specification);

        Task Save();
    }
}
