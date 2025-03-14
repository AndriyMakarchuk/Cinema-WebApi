using DataAccess.Entities;
using DataAccess.Entities.MovieInformation;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extencions.Data
{
    public static class SeedData
    {
        public static void SeedUserList(this ModelBuilder modelBuilder)
        {
            User[] userList = new User[1];
            userList[0] = new User() { Id = 1, UserName = "admin", Email="Admin", PasswordHash="admin", Role="admin"};
            modelBuilder.Entity<User>().HasData(userList);
        }
        public static void SeedGenreList(this ModelBuilder modelBuilder)
        {
            //GenresEnum[] genres = Enum.GetValues(typeof(GenresEnum)).Cast<GenresEnum>().ToArray();
            //Genre[] genreList = new Genre[genres.Length];
            //for (int i = 0; i < genres.Length; i++)
            //{
            //    genreList[i] = new Genre() { Id = i + 1, GenreName = genres[i] };
            //}
            //modelBuilder.Entity<Genre>().HasData(genreList);
            Genre[] genreList = new Genre[19];
            genreList[0] = new Genre() { Id = 1, GenreName = "Action", Movies = null};
            genreList[1] = new Genre() { Id = 2, GenreName = "Adventure", Movies = null };
            genreList[2] = new Genre() { Id = 3, GenreName = "Animation", Movies = null };
            genreList[3] = new Genre() { Id = 4, GenreName = "Comedy", Movies = null };
            genreList[4] = new Genre() { Id = 5, GenreName = "Crime", Movies = null };
            genreList[5] = new Genre() { Id = 6, GenreName = "Documentary", Movies = null };
            genreList[6] = new Genre() { Id = 7, GenreName = "Drama", Movies = null };
            genreList[7] = new Genre() { Id = 8, GenreName = "Family", Movies = null };
            genreList[8] = new Genre() { Id = 9, GenreName = "Fantasy", Movies = null };
            genreList[9] = new Genre() { Id = 10, GenreName = "History", Movies = null };
            genreList[10] = new Genre() { Id = 11, GenreName = "Horror", Movies = null };
            genreList[11] = new Genre() { Id = 12, GenreName = "Music", Movies = null };
            genreList[12] = new Genre() { Id = 13, GenreName = "Mystery", Movies = null };
            genreList[13] = new Genre() { Id = 14, GenreName = "Romance", Movies = null };
            genreList[14] = new Genre() { Id = 15, GenreName = "Science Fiction", Movies = null };
            genreList[15] = new Genre() { Id = 16, GenreName = "TV Movie", Movies = null };
            genreList[16] = new Genre() { Id = 17, GenreName = "Triller", Movies = null };
            genreList[17] = new Genre() { Id = 18, GenreName = "War", Movies = null };
            genreList[18] = new Genre() { Id = 19, GenreName = "Western", Movies = null };
            modelBuilder.Entity<Genre>().HasData(genreList);
        }
        public static void SeedMovieList(this ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Movie>().HasData(new Movie[]
            //{
            //    new Movie() { Id = 1,
            //        Cast = "sdfg sdf",
            //        Description = "ds",
            //        Rating = 9,
            //        Title = "tl",
            //        TrailerLink = "https://www.youtube.com/watch?v=xqCNVGCPtJ8&ab_channel=MonolithGD",
            //        Genres = new List<GenreMovie>(new GenreMovie[] {
            //            new GenreMovie() { Genre = new Genre() { GenreName = GenresEnum.Action, Id = 1 } },
            //            new GenreMovie() { Genre = new Genre() { GenreName = GenresEnum.Mysteries, Id = 2 } }, })
            //    }
            //});
        }
    }
}
