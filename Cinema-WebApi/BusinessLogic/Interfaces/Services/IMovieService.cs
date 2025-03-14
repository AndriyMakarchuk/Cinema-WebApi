using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IMovieService : IBaseCRUD<MovieDTO>
    {
        MovieDTO GetMovieById(int id);
        List<MovieDTO> GetMoviesByIds(int[] ids);
        List<MovieDTO> GetMoviesByGenres(List<GenreDTO> genreDTOs);
        List<MovieDTO> GetMoviesByActors(List<ActorDTO> ActorDTOs);
        List<MovieDTO> GetMoviesByName(string name);
    }
}
