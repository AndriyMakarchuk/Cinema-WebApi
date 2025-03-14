namespace BusinessLogic.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public float Rating { get; set; }
        public string TrailerLink { get; set; }
        public string ThumbnailLink { get; set; }
        public List<RoleDTO> Roles { get; set; }
        public List<GenreDTO> Genres { get; set; }
    }
}
