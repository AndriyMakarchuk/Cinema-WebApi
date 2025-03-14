using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services.Base;
using DataAccess.Entities.MovieInformation;
using DataAccess.Interfaces;
using DataAccess.Specifications;

namespace BusinessLogic.Services
{
    public class GenreService : BaseServiceClass<Genre, GenreDTO>, IGenreService
    {
        public GenreService(IMapper mapper, IRepository<Genre> repository) : base(mapper, repository)
        {
        }       
        public GenreDTO GetById(int id)
        {
            var result = Repository.GetFirstBySpec(new GenreSpecifications.ById(id));
            return Mapper.Map<GenreDTO>(result);
        }
        public List<GenreDTO> GetByIds(int[] ids)
        {
            var result = Repository.GetListBySpec(new GenreSpecifications.ByIds(ids));
            return Mapper.Map<List<GenreDTO>>(result);
        }

        public GenreDTO GetByName(string name)
        {
            var result = Repository.GetFirstBySpec(new GenreSpecifications.ByName(name));
            return Mapper.Map<GenreDTO>(result);
        }
        public List<GenreDTO> GetByNames(string[] names)
        {
            var result = Repository.GetListBySpec(new GenreSpecifications.ByNames(names));
            return Mapper.Map<List<GenreDTO>>(result);
        }
        public override void Create(GenreDTO dto)
        {
            if(GetByName(dto.GenreName) == null)
                base.Create(dto);
        }
    }
}
