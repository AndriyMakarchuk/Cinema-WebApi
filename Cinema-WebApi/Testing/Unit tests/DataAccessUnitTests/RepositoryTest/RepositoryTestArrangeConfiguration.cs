using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccessUnitTesting.MockObjects;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DataAccessUnitTests.RepositoryTest
{
    internal class RepositoryTestArrangeConfiguration
    {
        public List<EntityMock> Data {  get; private set; }
        public Mock<DbSet<EntityMock>> DbSetMock { get; private set; }
        public Mock<MockContext> ContextMock { get; private set; }
        public IRepository<EntityMock> Repository { get; private set; }

        private RepositoryTestArrangeConfiguration(List<EntityMock> data = null)
        {
            Data = (data != null) ? data : new List<EntityMock>
            {
                new EntityMock()
                {
                    Id = 0,
                    Name = "ent_0",
                    Description = "testDescr"
                },
                new EntityMock()
                {
                    Id = 1,
                    Name = "ent_1",
                    Description = "testDescr"
                },
                new EntityMock()
                {
                    Id = 2,
                    Name = "ent_2",
                    Description = "testDescr"
                }
            };
            DbSetMock = new Mock<DbSet<EntityMock>>();
            ContextMock = new Mock<MockContext>();
        }
        public static RepositoryTestArrangeConfiguration CreateConfiguredForNonQueryTest(List<EntityMock> data = null)
        {
            RepositoryTestArrangeConfiguration testArangeConfiguration = new RepositoryTestArrangeConfiguration(data);

            testArangeConfiguration.ContextMock.Setup(c => c.Entities).Returns(testArangeConfiguration.DbSetMock.Object);

            testArangeConfiguration.Repository = 
                new Repository<EntityMock>(testArangeConfiguration.ContextMock.Object, 
                testArangeConfiguration.DbSetMock.Object);

            return testArangeConfiguration;
        }
        public static RepositoryTestArrangeConfiguration CreateConfiguredForQueryTest(List<EntityMock> data = null)
        {
            RepositoryTestArrangeConfiguration testArangeConfiguration = new RepositoryTestArrangeConfiguration(data); 

            var queryableData = testArangeConfiguration.Data.AsQueryable();

            testArangeConfiguration.DbSetMock.As<IQueryable<EntityMock>>()
                .Setup(m => m.Provider).Returns(queryableData.Provider);
            testArangeConfiguration.DbSetMock.As<IQueryable<EntityMock>>()
                .Setup(m => m.Expression).Returns(queryableData.Expression);
            testArangeConfiguration.DbSetMock.As<IQueryable<EntityMock>>()
                .Setup(m => m.ElementType).Returns(queryableData.ElementType);
            testArangeConfiguration.DbSetMock.As<IQueryable<EntityMock>>()
                .Setup(m => m.GetEnumerator()).Returns(() => queryableData.GetEnumerator());

            testArangeConfiguration.ContextMock.Setup(c => c.Entities).Returns(testArangeConfiguration.DbSetMock.Object);

            testArangeConfiguration.Repository = 
                new Repository<EntityMock>(testArangeConfiguration.ContextMock.Object, 
                testArangeConfiguration.DbSetMock.Object);

            return testArangeConfiguration;
        }
    }
}
