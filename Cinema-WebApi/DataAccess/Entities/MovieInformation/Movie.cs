using DataAccess.Interfaces;

namespace DataAccess.Entities.MovieInformation
{
    public class Movie : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public string TrailerLink { get; set; }
        public string ThumbnailLink { get; set; }
        public List<MovieActor> Actors { get; set; }
        public List<GenreMovie> Genres { get; set; }
    }
}
