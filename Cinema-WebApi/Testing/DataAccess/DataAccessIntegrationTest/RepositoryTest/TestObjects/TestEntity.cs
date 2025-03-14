using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessUnitTesting.MockObjects
{
    [PrimaryKey(nameof(Id))]
    public class TestEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
