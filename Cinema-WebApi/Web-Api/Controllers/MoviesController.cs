using System.Security.Claims;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IActorService _actorService;
        private IEnumerable<GenreDTO> _genres;
        private MovieAddViewModel _model;
        public MoviesController(IMovieService movieService, IGenreService genreService, IActorService actorService)
        {
            _movieService = movieService;
            _genreService = genreService;
            _actorService = actorService;
            _genres = _genreService.GetAll();
            _model = new MovieAddViewModel();
            _model.Genres = _genres;
        }
        //GET: /Movies/Index or /Movies
        public IActionResult Index()
        {
            List<MovieDTO> movies = _movieService.GetAll();
            return View(movies);
        }
        //GET: /Movies/Details  
        public IActionResult Details(int id)
        {
            return View(_movieService.GetMovieById(id));
        }
        //GET: /Movies/Add
        [Route("/Movies/Add")]
        [Route("/Movies/Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(int id = -1)
        {
            string route = (HttpContext.GetEndpoint() as RouteEndpoint).RoutePattern.RawText;
            if (route.Contains("Movies/Edit/{id}")) 
            { 
                _model.Movie = _movieService.GetMovieById(id);
                //PageOpenMode.OpenNextPageInSettingMode(PageModes.Update);
            }
            return View(_model);
        }
        //POST: /Movies/Edit
        [HttpPost]
        [Route("/Movies/Edit")]
        public IActionResult Update(MovieAddViewModel data)
        {
            _movieService.Update(ParseData(data, _model.Movie));
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [Route("/Movies/Add")]
        [Authorize(Roles = "Admin")]
        public IActionResult Add(MovieAddViewModel data)
        {
            _movieService.Create(ParseData(data, _model.Movie));
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult AddRole(ActorDTO actor)
        {
            return RedirectToAction("Add");
        }
        private MovieDTO ParseData(MovieAddViewModel data, MovieDTO destination)
        {
            //Trimming las ';' Without this last element of array after
            //splitting will be an empty string;
            destination = data.Movie;
            if (data.GenreString != null && data.GenreString.Length != 0)
            {
                data.GenreString = data.GenreString.TrimEnd(';');
                string[] genreNames = data.GenreString.Split(';');
                destination.Genres = _genreService.GetByNames(genreNames);
            }
            else
            {
                destination.Genres = new List<GenreDTO>();
            }

            destination.Roles = new List<RoleDTO>();

            if (data.ActorNameString != null && data.ActorNameString.Length != 0)
            {
                data.ActorNameString = data.ActorNameString.TrimEnd(';');
                data.RoleNameString = data.RoleNameString.TrimEnd(';');
                data.MainRoleString = data.MainRoleString.TrimEnd(';');

                string[] actorNames = data.ActorNameString.Split(";");
                string[] roleNames = data.RoleNameString.Split(";");
                string[] mainRole = data.MainRoleString.Split(";");

                for (int i = 0; i < actorNames.Length; i++)
                {
                    Console.WriteLine(mainRole[i]);
                    RoleDTO roleDTO = new RoleDTO();
                    roleDTO.ActorId = _actorService.GetActorByName(actorNames[i]).Id;
                    roleDTO.Role = roleNames[i];
                    roleDTO.IsMainRole = mainRole[i] == "true";
                    destination.Roles.Add(roleDTO);
                }
            }
            return destination;
        }
        [HttpDelete]
        public ActionResult Delete(int id) 
        {

            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized();
            }
            if (User.FindFirst(ClaimTypes.Role)?.Value != "Admin")
            {
                return Forbid();
            }
            var _movieToDelete = _movieService.GetMovieById(id);
            if (_movieToDelete == null)
            {
                return NotFound($"Movie with id={id} not found");
            }
            else
            {
                _movieService.Delete(_movieToDelete);
                return Ok();
            }
        }
    }
}
