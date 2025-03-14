using DataAccess.Interfaces ;

namespace DataAccess.Entities
{
    public class Session : IEntity
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public DateTime SessionDate { get; set; }

        public int HallId { get; set; }
    }
}
