namespace TestMVC.Models
{
    public class SeedData
    {
        public static void Initialize(AppDBContext dbContext)
        {
            dbContext.Films.AddRange(
                new Film
                {
                    Id = 1,
                    Name = "Dune: Part One",
                    Director = "Denis Villeneuve",
                    Release = new DateTime(2021,9,3)  
                },
                new Film
                {
                    Id = 2,
                    Name = "Dune: Part Two",
                    Director = "Denis Villeneuve",
                    Release = new DateTime(2024, 2, 28)
                },
                new Film
                {
                    Id = 3,
                    Name = "Road House",
                    Director = "Doug Liman",
                    Release = new DateTime(2024, 2, 28)
                },
                new Film
                {
                    Id = 4,
                    Name = "The Gentlemen",
                    Director = "Guy Ritchie",
                    Release = new DateTime(2019, 2, 28)
                },
                new Film
                {
                    Id = 5,
                    Name = "Oppenheimer",
                    Director = "Christopher Nolan",
                    Release = new DateTime(2023, 6, 11)
                }
              );

            dbContext.Categories.AddRange(
                new Category
                {
                    Id = 1,
                    Name = "SciFi"
                },
                new Category
                {
                    Id = 2,
                    Name = "Action"
                },
                new Category
                {
                    Id = 3,
                    Name = "Thriller"
                },
                new Category
                {
                    Id = 4,
                    Name = "Historical"
                }
              );

            dbContext.FilmCategories.AddRange(
                new FilmCategory
                {
                    Id = 1,
                    FilmId = 1,
                    CategoryId = 1
                },
                new FilmCategory
                {
                    Id = 2,
                    FilmId = 2,
                    CategoryId = 1
                },
                new FilmCategory
                {
                    Id = 3,
                    FilmId = 3,
                    CategoryId = 2
                },
                new FilmCategory
                {
                    Id = 4,
                    FilmId = 4,
                    CategoryId = 2
                },
                new FilmCategory
                {
                    Id = 5,
                    FilmId = 5,
                    CategoryId = 4
                },
                new FilmCategory
                {
                    Id = 6,
                    FilmId = 5,
                    CategoryId = 3
                }

               );
            dbContext.SaveChanges();
        }
    }
}
