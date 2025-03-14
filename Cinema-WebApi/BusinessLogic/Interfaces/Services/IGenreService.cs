using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IGenreService : IBaseCRUD<GenreDTO>
    {
        GenreDTO GetByName(string name);
        List<GenreDTO> GetByNames(string[] name);
        GenreDTO GetById(int id);
        List<GenreDTO> GetByIds(int[] ids);
    }
}
