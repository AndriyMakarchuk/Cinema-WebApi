using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessUnitTesting.MockObjects
{
    public class EntityMock : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
