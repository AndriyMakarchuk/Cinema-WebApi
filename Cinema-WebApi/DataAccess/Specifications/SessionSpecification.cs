using Ardalis.Specification;
using DataAccess.Entities;

namespace DataAccess.Specifications
{
    public class SessionSpecification
    {
        public class All : Specification<Session>
        {
            public All()
            {
                Query
                    .Include(x => x.MovieId)
                    .Include(x => x.HallId);
            }
        }

        public class ByIds : Specification<Session>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id))
                    .Include(x => x.MovieId)
                    .Include(x => x.HallId);
            }
        }

        public class ById : Specification<Session>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.MovieId)
                    .Include(x => x.HallId);
            }
        }

        public class ByCinemaHall : Specification<Session>
        {
            public ByCinemaHall(int cinemaHallId)
            {
                Query
                    .Where(x => x.HallId == cinemaHallId)
                    .Include(x => x.MovieId)
                    .Include(x => x.HallId);
            }
        }

        public class ByMovie : Specification<Session>
        {
            public ByMovie(int movieId)
            {
                Query
                    .Where(x => x.MovieId == movieId)
                    .Include(x => x.MovieId)
                    .Include(x => x.HallId);
            }
        }

        public class ByTimeRange : Specification<Session>
        {
            public ByTimeRange(DateTime startTime, DateTime endTime)
            {
                Query
                    .Where(x => x.SessionDate >= startTime && x.SessionDate <= endTime)
                    .Include(x => x.MovieId)
                    .Include(x => x.HallId);
            }
        }
    }
}