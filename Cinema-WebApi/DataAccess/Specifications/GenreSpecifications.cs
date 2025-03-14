using Ardalis.Specification;
using DataAccess.Entities.MovieInformation;

namespace DataAccess.Specifications
{
    public class GenreSpecifications
    {
        public class ByIds : Specification<Genre>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.Movies);
            }
        }
        public class ById : Specification<Genre>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Movies);
            }
        }
        public class ByName : Specification<Genre>
        {
            public ByName(string name)
            {
                Query.
                    Where(x => x.GenreName.ToLower() == name.ToLower())
                    .Include(x => x.Movies);
            }
        }
        public class ByNames : Specification<Genre>
        {
            public ByNames(string[] names)
            {
                names = names.ToList().ConvertAll(n => n.ToLower()).ToArray();
                Query.
                    Where(x => names.Contains(x.GenreName.ToLower()))
                    .Include(x => x.Movies);
            }
        }
    }
}
