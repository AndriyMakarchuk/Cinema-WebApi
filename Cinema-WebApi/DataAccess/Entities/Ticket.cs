using DataAccess.Interfaces;

namespace DataAccess.Entities
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }

        public int SessionId { get; set; }
        public Session Session { get; set; }  // Navigation property

        public float Price { get; set; }

        public int PlaceRowNumber { get; set; }

        public int PlaceColumnNumber { get; set; }

        public int UserId { get; set; }  // Foreign Key
        public User User { get; set; }   // Navigation Property
    }
}