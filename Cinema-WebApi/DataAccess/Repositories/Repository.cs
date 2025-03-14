using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DataAccess.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Diagnostics;

namespace DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<TEntity>();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await (from e in _dbSet select e).ToListAsync();
        }
        public virtual async Task<TEntity?> GetById(int id)
        {
            List<TEntity> entities = await (from e in _dbSet where e.Id == id select e).ToListAsync();
            return entities.FirstOrDefault();
        }

        public async Task Insert(TEntity entity)
        {
            if (await GetById(entity.Id) == null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public async Task Delete(int id)
        {
            int deleted = await _dbSet.Where(e => e.Id == id).ExecuteDeleteAsync();
            if(deleted == 0)
            {
                throw new ArgumentException($"Entity with id={id} wasn't found");
            }
        }
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListBySpec(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<TEntity?> GetFirstBySpec(ISpecification<TEntity> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> specification)
        {
            var evaluator = new SpecificationEvaluator();
            return evaluator.GetQuery(_dbSet, specification);
        }
    }
}


