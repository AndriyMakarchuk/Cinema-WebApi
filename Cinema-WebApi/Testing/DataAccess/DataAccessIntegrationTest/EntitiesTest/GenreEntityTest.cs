using DataAccess.Entities.MovieInformation;

namespace DataAccessIntegrationTest.EntitiesTest
{
    public class GenreEntityTest
    {
        [Test]
        public void Insert_One_Success()
        {
            //Arrange
            var context = new TestCinemaContext();
            Genre genre = new Genre() { GenreName = "testName" };

            //Act
            context.Genres.Add(genre);
            context.SaveChanges();
            List<Genre> addedGenres = context.Genres.ToList();

            //Assert
            Assert.AreEqual(1, addedGenres.Count);
            Assert.AreEqual(addedGenres.First().GenreName, genre.GenreName);

        }
        [Test]
        public void Insert_One_EmptyName_Exeption()
        {
            //Arrange
            var context = new TestCinemaContext();
            Genre genre = new Genre();

            //Act
            context.Genres.Add(genre);
            //Assert
            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => context.SaveChanges());
        }
        [Test]
        public void Insert_Several_Success()
        {
            //Arrange
            var context = new TestCinemaContext();
            List<Genre> genres = new List<Genre>()
            {
                new Genre()
                {
                    GenreName = "test1"
                },
                new Genre()
                {
                    GenreName = "test2"
                }
            };

            //Act
            foreach (var genre in genres)
            {
                context.Genres.Add(genre);
            }
            context.SaveChanges();
            List<Genre> addedGenres = context.Genres.ToList();

            //Assert
            Assert.AreEqual(addedGenres.Count(), 2);
            Assert.AreEqual(addedGenres[0].GenreName, genres[0].GenreName);
            Assert.AreEqual(addedGenres[1].GenreName, genres[1].GenreName);
        }
        [Test]
        public void Insert_SeveralSameName_Exeption()
        {
            //Arrange
            var context = new TestCinemaContext();
            List<Genre> genres = new List<Genre>()
            {
                new Genre()
                {
                    GenreName = "test"
                },
                new Genre()
                {
                    GenreName = "test"
                }
            };

            //Act
            foreach (var genre in genres)
            {
                context.Genres.Add(genre);
            }

            //Assert
            Assert.Throws<Microsoft.EntityFrameworkCore.DbUpdateException>(() => context.SaveChanges());
        }
    }
}
