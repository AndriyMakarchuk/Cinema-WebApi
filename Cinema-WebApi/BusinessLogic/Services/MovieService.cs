using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using DataAccess.Interfaces;
using DataAccess.Entities.MovieInformation;
using BusinessLogic.Services.Base;
using Ardalis.Specification;
using System.Linq;
using DataAccess.Specifications;

namespace BusinessLogic.Services
{
    public class MovieService : BaseServiceClass<Movie, MovieDTO>, IMovieService
    {
        public MovieService(IMapper mapper, IRepository<Movie> repository) : base(mapper, repository)
        {
        }

        public MovieDTO GetMovieById(int id)
        {
            var result = Repository.GetFirstBySpec(new MovieSpecification.ById(id));
            return Mapper.Map<MovieDTO>(result);
        }
        public List<MovieDTO> GetMoviesByIds(int[] ids)
        {
            var result = Repository.GetListBySpec(new MovieSpecification.ByIds(ids));
            return Mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByGenres(List<GenreDTO> genreDTOs) 
        {
            List<string> genres = genreDTOs.Select(g => g.GenreName).ToList();
            var result = Repository.GetListBySpec(new MovieSpecification.ByGenres(genres));
            return Mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByActors(List<ActorDTO> ActorDTOs)
        {
            List<int> actorsIds = ActorDTOs.Select(g => g.Id).ToList();
            var result = Repository.GetListBySpec(new MovieSpecification.ByActors(actorsIds));
            return Mapper.Map<List<MovieDTO>>(result);
        }
        public List<MovieDTO> GetMoviesByName(string name)
        {
            var result = Repository.GetListBySpec(new MovieSpecification.ByName(name));
            return Mapper.Map<List<MovieDTO>>(result);
        }

        public override void Update(MovieDTO dto)
        {
            Movie movie = Repository.GetFirstBySpec(new MovieSpecification.ById(dto.Id));
            MapMovie(dto, ref movie);
            Repository.Update(movie);
            Repository.Save();
        }
        //Custom mapper method. 
        //Update doesn't work with Automapper
        //DTO properties must be mapped into entity, retrived from DB. Not in new Entity instance
        private void MapMovie(MovieDTO dto, ref Movie entity)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Rating = dto.Rating;
            entity.ThumbnailLink = dto.ThumbnailLink;
            entity.TrailerLink = dto.TrailerLink;
            entity.Year = dto.Year;
            //Genres
            for (int i = entity.Genres.Count - 1; i >= 0; i--)
            {
                if (!dto.Genres.Select(x => x.Id).Contains(entity.Genres[i].GenreId))
                {
                    entity.Genres.RemoveAt(i);
                }
            }
            for (int i = 0; i < dto.Genres.Count; i++) 
            {
                if(!entity.Genres.Select(x => x.GenreId).Contains(dto.Genres[i].Id))
                {
                    GenreMovie genre = new GenreMovie()
                    {
                        GenreId = dto.Genres[i].Id,
                        MovieId = entity.Id
                    };
                    entity.Genres.Add(genre);
                }
            }
            //Roles
            for (int i = entity.Actors.Count - 1; i >= 0; i--)
            {
                if (!dto.Roles.Select(x => x.ActorId).Contains(entity.Actors[i].ActorId))
                {
                    entity.Actors.RemoveAt(i);
                }
            }
            for (int i = 0; i < dto.Roles.Count; i++)
            {
                if (!entity.Actors.Select(x => x.ActorId).Contains(dto.Roles[i].ActorId))
                {
                    MovieActor actor = new MovieActor()
                    {
                        ActorId = dto.Roles[i].ActorId,
                        Role = dto.Roles[i].Role,
                        IsMainRole = dto.Roles[i].IsMainRole,
                        MovieId = entity.Id
                    };
                    entity.Actors.Add(actor);
                }
                else
                {
                    MovieActor role = entity.Actors.Where(x => x.ActorId == dto.Roles[i].ActorId).ToList()[0];
                    role.Role = dto.Roles[i].Role;
                    role.IsMainRole = dto.Roles[i].IsMainRole;
                }
            }

        }
    }
}
