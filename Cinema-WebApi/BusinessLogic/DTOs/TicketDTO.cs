namespace BusinessLogic.DTOs
{
    public class TicketDTO
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public decimal Price { get; set; }
        public int PlaceRowNumber { get; set; }
        public int PlaceColumnNumber { get; set; }
        public string UserId { get; set; }
    }
}
