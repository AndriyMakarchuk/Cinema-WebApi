using DataAccess.Interfaces;

namespace DataAccess.Entities.MovieInformation
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public List<GenreMovie> Movies { get; set; }

    }
}
