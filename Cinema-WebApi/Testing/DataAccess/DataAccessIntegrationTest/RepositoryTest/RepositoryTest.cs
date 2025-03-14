using Ardalis.Specification.EntityFrameworkCore;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using DataAccessIntegrationTest.RepositoryTest.TestObjects;
using DataAccessUnitTesting.MockObjects;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace DataAccessIntegrationTest.RepositoryTest
{
    public class RepositoryTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task InsertTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            repository.GetById(Arg.Any<int>()).Returns(Task.FromResult<TestEntity>(null));
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                },
                new TestEntity()
                {
                    Name = "entity3"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                await repository.Insert(dataItem);
            }
            context.SaveChanges();
            var enteties = context.Entities.OrderBy(ent => ent.Name).ToList();
            //Assert
            Assert.AreEqual(enteties.Count, 3);
            Assert.AreEqual(enteties[0].Name, "entity1");
            Assert.AreEqual(enteties[1].Name, "entity2");
            Assert.AreEqual(enteties[2].Name, "entity3");
        }
        [Test]
        public async Task GetAllTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                },
                new TestEntity()
                {
                    Name = "entity3"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            context.SaveChanges();
            var enteties = (await repository.GetAll()).OrderBy(e => e.Name).ToList();
            //Assert
            Assert.AreEqual(enteties.Count, 3);
            Assert.AreEqual(enteties[0].Name, "entity1");
            Assert.AreEqual(enteties[1].Name, "entity2");
            Assert.AreEqual(enteties[2].Name, "entity3");
        }
        [Test]
        public async Task GetByIdTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                },
                new TestEntity()
                {
                    Name = "entity3"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            context.SaveChanges();
            var ent1 = await repository.GetById(1);
            var ent2 = await repository.GetById(2);
            var ent3 = await repository.GetById(3);
            //Assert
            Assert.AreEqual(ent1.Name, "entity1");
            Assert.AreEqual(ent2.Name, "entity2");
            Assert.AreEqual(ent3.Name, "entity3");
        }
        [Test]
        public async Task DeleteTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                },
                new TestEntity()
                {
                    Name = "entity3"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            context.SaveChanges();
            await repository.Delete(1);
            await repository.Delete(3);
            context.SaveChanges();
            var ent1 = (from e in context.Entities where e.Id == 1 select e).ToList().FirstOrDefault();
            var ent2 = (from e in context.Entities where e.Id == 2 select e).ToList().FirstOrDefault();
            var ent3 = (from e in context.Entities where e.Id == 3 select e).ToList().FirstOrDefault();
            //Assert
            Assert.IsNull(ent1);
            Assert.AreEqual(ent2.Name, "entity2");
            Assert.IsNull(ent3);
        }
        [Test]
        public async Task UpdateTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            context.SaveChanges();

            var ent1 = (from e in context.Entities where e.Id == 1 select e).ToList().FirstOrDefault();
            var ent2 = (from e in context.Entities where e.Id == 2 select e).ToList().FirstOrDefault();

            ent2.Name = "updated";
            repository.Update(ent2);
            context.SaveChanges();

            var updatedEntity = (from e in context.Entities where e.Id == 2 select e).ToList().FirstOrDefault();
            //Assert            
            Assert.AreEqual(ent1.Name, "entity1");
            Assert.AreEqual(updatedEntity.Name, "updated");
        }
        [Test]
        public async Task SaveTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            await repository.Save();

            var ent1 = (from e in context.Entities where e.Id == 1 select e).ToList().FirstOrDefault();
            var ent2 = (from e in context.Entities where e.Id == 2 select e).ToList().FirstOrDefault();
            //Assert            
            Assert.AreEqual(ent1.Name, "entity1");
            Assert.AreEqual(ent2.Name, "entity2");
        }
        [Test]
        public async Task GetListBySpecTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1"
                },
                new TestEntity()
                {
                    Name = "entity2"
                },
                new TestEntity()
                {
                    Name = "otherName"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            context.SaveChanges();

            List<TestEntity> entityList = (await repository.GetListBySpec(new TestEntitySpecifications.ByNamePartitial("ent")))
            .OrderBy(e => e.Name).ToList();

            //Assert
            Assert.AreEqual(entityList.Count(), 2);
            Assert.AreEqual(entityList[0].Name, "entity1");
            Assert.AreEqual(entityList[1].Name, "entity2");
        }
        [Test]
        public async Task GetFirstBySpecTest()
        {
            //Arrange
            var context = new RepositoryTestContext();
            var repository = Substitute.ForPartsOf<Repository<TestEntity>>(context);
            TestEntity[] data = new TestEntity[]
            {
                new TestEntity()
                {
                    Name = "entity1asdfhageaddfasdff"
                },
                new TestEntity()
                {
                    Name = "entity1"
                }
            };
            //Act
            foreach (var dataItem in data)
            {
                context.Entities.Add(dataItem);
            }
            context.SaveChanges();

            var entity = await repository.GetFirstBySpec(new TestEntitySpecifications.ByNameFull("entity1"));

            //Assert
            Assert.AreEqual(entity.Name, "entity1");
        }
    }
}
