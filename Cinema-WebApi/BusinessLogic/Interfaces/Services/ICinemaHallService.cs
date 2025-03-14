using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface ICinemaHallService : IBaseCRUD<CinemaHallDTO> 
    {
        CinemaHallDTO GetCinemaHallById(int id);
    }
}
