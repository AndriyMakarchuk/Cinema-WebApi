namespace BusinessLogic.DTOs
{
    public class RoleDTO
    {
        public int MovieId { get; set; }
        public MovieDTO Movie { get; set; }
        public int ActorId { get; set; }
        public ActorDTO Actor { get; set; }
        public string Role { get; set; }
        public bool IsMainRole { get; set; }
    }
}
