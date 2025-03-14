using Ardalis.Specification;
using DataAccess.Entities;
using DataAccess.Entities.MovieInformation;
using DataAccess.Extencions.EntityExtencions;

namespace DataAccess.Specifications
{
    public class UserSpecification
    {
        public class All : Specification<User>
        {
            public All()
            {
                Query
                    .Include(x => x.Id).Include(x => x.UserName).Include(x => x.Role);
            }
        }
        public class ByIds : Specification<User>
        {
            public ByIds(int[] ids)
            {
                Query
                    .Where(x => ids.Contains(x.Id));
            }
        }
        public class ById : Specification<User>
        {
            public ById(int id)
            {
                Query
                    .Where(x => x.Id == id);
            }
        }
        public class ByEmail : Specification<User>
        {
            public ByEmail(string email)
            {
                Query
                    .Where(x => x.Email == email);
            }
        }
        public class ByUserName : Specification<User>
        {
            public ByUserName(string userName)
            {
                Query
                    .Where(x => x.UserName == userName);
            }
        }
        public class ByRole : Specification<User>
        {
            public ByRole(string role)
            {
                Query
                    .Where(x => x.Role == role);
            }
        }
        public class ByRoles : Specification<User>
        {
            public ByRoles(string[] role)
            {
                Query
                    .Where(x => role.Contains(x.Role));
            }
        }
    }
}
