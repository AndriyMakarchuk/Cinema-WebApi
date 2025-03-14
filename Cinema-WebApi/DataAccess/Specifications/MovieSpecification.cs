using Ardalis.Specification;
using DataAccess.Entities.MovieInformation;
using DataAccess.Extencions.EntityExtencions;

namespace DataAccess.Specifications
{
    public class MovieSpecification
    {
        public class All : Specification<Movie>
        {
            public All()
            {
                Query
                    .Include(x => x.Genres).ThenInclude(x => x.Genre)
                    .Include(x => x.Actors).ThenInclude(x => x.Actor);
            }
        }
        public class ByIds : Specification<Movie>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Genres).ThenInclude(x => x.Genre)
                    .Include(x => x.Actors).ThenInclude(x => x.Actor);
            }
        }
        public class ById : Specification<Movie>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Genres).ThenInclude(x => x.Genre)
                    .Include(x => x.Actors).ThenInclude(x => x.Actor);
            }
        }
        public class ByGenres : Specification<Movie>
        {
            public ByGenres(List<string> genres)
            {
                Query.
                    Where(x => x.ContainsAllGenres(genres))
                    .Include(x => x.Genres).ThenInclude(x => x.Genre)
                    .Include(x => x.Actors).ThenInclude(x => x.Actor);
            }
        }
        public class ByActors : Specification<Movie>
        {
            public ByActors(List<int> actorIds)
            {
                Query.
                    Where(x => x.ContainsAllActors(actorIds))
                    .Include(x => x.Genres).ThenInclude(x => x.Genre)
                    .Include(x => x.Actors).ThenInclude(x => x.Actor);
            }
        }
        public class ByName : Specification<Movie>
        {
            public ByName(string name)
            {
                Query.
                    Where(x => x.Title.ToLower().StartsWith(name.ToLower()))
                    .Include(x => x.Genres).ThenInclude(x => x.Genre)
                    .Include(x => x.Actors).ThenInclude(x => x.Actor);
            }
        }
    }
}
