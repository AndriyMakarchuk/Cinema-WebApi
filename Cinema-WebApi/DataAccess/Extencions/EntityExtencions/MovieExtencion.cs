using System.Linq;
using DataAccess.Entities.MovieInformation;

namespace DataAccess.Extencions.EntityExtencions
{
    static public class MovieExtencion
    {
        public static bool ContainsAllGenres(this Movie movie, List<string> genresNames) 
        {
            return genresNames.Intersect<string>(movie.Genres.Select(e => e.Genre.GenreName)).Count<string>() == genresNames.Count;
        }
        public static bool ContainsAllActors(this Movie movie, List<int> actorIds)
        {
            return actorIds.Intersect<int>(movie.Actors.Select(e => e.ActorId)).Count<int>() == actorIds.Count;
        }
    }
}
