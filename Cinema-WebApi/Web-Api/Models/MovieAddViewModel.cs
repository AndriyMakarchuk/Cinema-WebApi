using BusinessLogic.DTOs;
using DataAccess.Entities.MovieInformation;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Models
{
    public class MovieAddViewModel
    {
        public MovieAddViewModel()
        {
            Movie = new MovieDTO();
            Movie.Genres = new List<GenreDTO>();
            Movie.Roles = new List<RoleDTO>();
        }
        public MovieDTO Movie { get; set; }
        public IEnumerable<GenreDTO> Genres { get; set; }
        public string GenreString {  get; set; }
        public string RoleNameString { get; set; }
        public string ActorNameString {get; set; }
        public string MainRoleString { get; set; }

    }
}
