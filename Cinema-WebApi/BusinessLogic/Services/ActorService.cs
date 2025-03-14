using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services.Base;
using DataAccess.Entities.MovieInformation;
using DataAccess.Interfaces;
using DataAccess.Specifications;

namespace BusinessLogic.Services
{
    public class ActorService : BaseServiceClass<Actor, ActorDTO>, IActorService
    {
        public ActorService(IMapper mapper, IRepository<Actor> repository) : base(mapper, repository)
        {
        }

        public ActorDTO GetActorById(int id)
        {
            var result = Repository.GetFirstBySpec(new ActorSpecifications.ById(id));
            return Mapper.Map<ActorDTO>(result);
        }

        public List<ActorDTO> GetActorsByIds(int[] ids)
        {
            var result = Repository.GetListBySpec(new ActorSpecifications.ByIds(ids));
            return Mapper.Map<List<ActorDTO>>(result);
        }

        public List<ActorDTO> GetActorsByMovie(MovieDTO movie)
        {
            var result = Repository.GetFirstBySpec(new ActorSpecifications.ByMovie(movie.Id));
            return Mapper.Map<List<ActorDTO>>(result);
        }

        public List<ActorDTO> SearchActorsByName(string name)
        {
            var result = Repository.GetListBySpec(new ActorSpecifications.ByName(name));
            return Mapper.Map<List<ActorDTO>>(result);
        }
        public ActorDTO GetActorByName(string name)
        {
            var result = Repository.GetFirstBySpec(new ActorSpecifications.ByNameFulCoincidence(name));
            return Mapper.Map<ActorDTO>(result);
        }
        public List<ActorDTO> GetActorsByNames(string[] names)
        {
            var result = Repository.GetListBySpec(new ActorSpecifications.ByNames(names));
            return Mapper.Map<List<ActorDTO>>(result);
        }
        public void Delete(int id) 
        { 
            Repository.Delete(id);
            Repository.Save();
        }
    }
}
