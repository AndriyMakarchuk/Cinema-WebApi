using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using DataAccess.Entities.Specifications;
using DataAccess.Interfaces;

namespace BusinessLogic.Services.Base
{
    public class BaseServiceClass<TEntity, T_DTO> : IBaseCRUD<T_DTO>
        where TEntity : class, IEntity
        where T_DTO : class
    {
        protected IMapper Mapper { get; private set; }
        protected IRepository<TEntity> Repository { get; private set; }
        public BaseServiceClass(IMapper mapper, IRepository<TEntity> repository) 
        {
            Mapper = mapper;
            Repository = repository;  
        }
        public virtual void Create(T_DTO dto)
        {
            var value = Mapper.Map<TEntity>(dto);
            Repository.Insert(value);
            Repository.Save();
        }

        public void Delete(T_DTO dto)
        {
            var value = Mapper.Map<TEntity>(dto);
            Repository.Delete(value.Id);
            Repository.Save();
        }

        public List<T_DTO> GetAll()
        {
            var result = Repository.GetAll();
            return Mapper.Map<List<T_DTO>>(result);
        }

        public virtual void Update(T_DTO dto)
        {
            var value = Mapper.Map<TEntity>(dto);
            Repository.Update(value);
            Repository.Save();
        }
    }
}
