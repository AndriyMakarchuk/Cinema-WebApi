using Ardalis.Specification;
using DataAccessUnitTesting.MockObjects;

namespace DataAccessIntegrationTest.RepositoryTest.TestObjects
{
    public class TestEntitySpecifications
    {
        public class ByNamePartitial : Specification<TestEntity>
        {
            public ByNamePartitial(string name)
            {
                Query
                    .Where(x => x.Name.Contains(name));
            }
        }
        public class ByNameFull : Specification<TestEntity>
        {
            public ByNameFull(string name)
            {
                Query
                    .Where(x => x.Name == name);
            }
        }
    }
}
