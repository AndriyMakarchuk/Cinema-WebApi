using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces.Services
{
    public interface IActorService : IBaseCRUD<ActorDTO>
    {
        void Delete(int id);
        ActorDTO GetActorById(int id);
        List<ActorDTO> GetActorsByIds(int[] ids);
        List<ActorDTO> SearchActorsByName(string name);
        ActorDTO GetActorByName(string name);
        List<ActorDTO> GetActorsByNames(string[] name);
        List<ActorDTO> GetActorsByMovie(MovieDTO movie);
    }
}
