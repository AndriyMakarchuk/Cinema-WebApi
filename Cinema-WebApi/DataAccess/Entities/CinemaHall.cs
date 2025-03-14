using DataAccess.Interfaces;

namespace DataAccess.Entities
{

    public class CinemaHall : IEntity
    {
        public int Id { get; set; }
        public int Places_rows_amount { get; set; }
        public int Places_columns_amount { get; set; }
    }
}