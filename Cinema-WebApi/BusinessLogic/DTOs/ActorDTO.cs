namespace BusinessLogic.DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BirthYear { get; set; }
        public string PhotoUrl { get; set; }
        public List<RoleDTO> Roles { get; set; }
    }
}
