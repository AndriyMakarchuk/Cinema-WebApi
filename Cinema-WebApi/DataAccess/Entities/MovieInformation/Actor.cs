using DataAccess.Interfaces;

namespace DataAccess.Entities.MovieInformation
{
    public class Actor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoUrl { get; set; }
        public ushort BirthYear { get; set; }
        public List<MovieActor> Movies { get; set; }
    }
}
