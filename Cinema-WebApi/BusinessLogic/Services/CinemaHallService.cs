using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using DataAccess.Entities;
using DataAccess.Interfaces;
using DataAccess.Specifications;

namespace BusinessLogic.Services.Base
{
    public class CinemaHallService : BaseServiceClass<CinemaHall, CinemaHallDTO>, ICinemaHallService
    {
        public CinemaHallService(IMapper mapper, IRepository<CinemaHall> repository) : base(mapper, repository)
        {
        }

        public CinemaHallDTO GetCinemaHallById(int id)
        {
            var result = Repository.GetFirstBySpec(new CinemaHallSpecifications.ById(id));
            return Mapper.Map<CinemaHallDTO>(result);
        }
    }
}
