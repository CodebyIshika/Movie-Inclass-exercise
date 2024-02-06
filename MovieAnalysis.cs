using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MovieExercise
{
    internal class MovieAnalysis
    {
        Database database = new Database();
        public void GetAllMoviesInCategory(string Category)
        {
            var getAllMoviesCategory = from obj in database.MoviesCollections where obj.Category == Category select obj;

            Console.WriteLine($"The movies of {Category} are :");
            foreach (var obj in getAllMoviesCategory)
            {
                Console.WriteLine($"Movie Id: {obj.MovieID}, Movie Title: {obj.Title}");
            }
        }

        public void GetCountInCategory(string Category)
        {
            var getAllMoviesCategory = from obj in database.MoviesCollections where obj.Category == Category select obj;

            int countOfMovies = getAllMoviesCategory.Count();
            Console.WriteLine($"The Count of {Category} Movies : {countOfMovies}");
        }

        public void MoviesInBudget(double Budget)
        {
            var getMoviesWithinBudget = database.MoviesCollections.Where(x => x.Budget < Budget)
                                       .Join(database.RatingCollection,
                                                            movies => movies.MovieID,
                                                            rating => rating.MovieId,
                                                            (movies, rating) => new
                                                            {
                                                                movieName = movies.Title,
                                                                budget = movies.Budget,
                                                                ratings = rating.Stars
                                                            });


            Console.WriteLine($"The movies within the Budget of {Budget}: ");
            foreach (var obj in getMoviesWithinBudget)
            {
                Console.WriteLine($"Movie Title: {obj.movieName}, Movie Budget: {obj.budget}, Movie Rating: {obj.ratings} ");
            }
        }

        public void MoviesInThe90s()
        {
            var moviesIn90s = database.MoviesCollections.Where(x => x.ReleaseYear >= 1990 && x.ReleaseYear <= 2000);

            Console.WriteLine("The Movies in 90s: ");
            foreach (var obj in moviesIn90s)
            {
                Console.WriteLine($"Movie Title: {obj.Title}, Release Year: {obj.ReleaseYear}");
            }
        }

        public void CalculateOverallRating(string name, int releaseYear)
        {
            var movieName = database.MoviesCollections.FirstOrDefault(x => x.Title ==  name && x.ReleaseYear == releaseYear );

            if( movieName != null )
            {
                var movieRating = database.RatingCollection.Where(x => x.MovieId == movieName.MovieID).Select(x => x.Stars);
                if (movieRating.Any())
                {
                    double averageRating = movieRating.Average();
                    Console.WriteLine($"The average rating for the movie with {name} and {releaseYear} is {averageRating} ");
                }
                else
                {
                    throw new InvalidOperationException($"There are no ratings present for {name}.");
                }
            }
            else
            {
                Console.WriteLine($"The movie with {name} and {releaseYear} doesn't exist.");
            }
        }

        public void HighestPaidSalary()
        {
            var highestSalary = database.Actors.Max(x  => x.Salary);
            Console.WriteLine($"The highest salary is {highestSalary}");
        }

        public void HighestPaidActor()
        {
            var highestSalary = database.Actors.Max(x => x.Salary);
            var highestPaidActor = database.Actors.Where(x => x.Salary == highestSalary);

            foreach (var obj in highestPaidActor)
            {
                Console.WriteLine($"The highest paid actor is {obj.Name} with {highestSalary}");
            }
        }

        public void HighestPaidActorByOrder()
        {
            var highestPaidActor = database.Actors.OrderBy(x => x.Salary).Last();

            Console.WriteLine($"The highest paid actor is {highestPaidActor.Name} with {highestPaidActor.Salary}");
        }

        public void GetMovieDetails()
        {
            var displayMovieInfo = database.MoviesCollections.Join(database.RatingCollection,
                                                            movies => movies.MovieID,
                                                            rating => rating.MovieId,
                                                            (movies, rating) => new
                                                            {
                                                                movieId = movies.MovieID,
                                                                movieName = movies.Title,
                                                                budget = movies.Budget,
                                                                releaseYear = movies.ReleaseYear,
                                                                ratings = rating.Stars,
                                                            });

            foreach (var movie in displayMovieInfo)
            {
                Console.WriteLine($"Movie Id: {movie.movieId}, Movie Name: {movie.movieName}, Movie Budget: {movie.budget}" +
                                  $" Release Year: {movie.releaseYear}, Ratings: {movie.ratings}");
            }
        }

        public void GetExtendedMovieDetails()
        {
            var displayMovieInfo = database.MoviesCollections.GroupJoin(database.RatingCollection,
                                                           movies => movies.MovieID,
                                                           rating => rating.MovieId,
                                                           (movies, rating) => new
                                                           {
                                                               movieId = movies.MovieID,
                                                               movieName = movies.Title,
                                                               budget = movies.Budget,
                                                               releaseYear = movies.ReleaseYear,
                                                               ratings = rating.Select(x => x.Stars)
                                                           });

            foreach (var movie in displayMovieInfo)
            {
                Console.WriteLine($"Movie Id: {movie.movieId}, Movie Name: {movie.movieName}, Movie Budget: {movie.budget}" +
                                  $" Release Year: {movie.releaseYear}, Ratings: {string.Join(", ", movie.ratings)} ");
            }
        }

        // groupjoin() is a combination of groupby and join
        public void GetMovieDetailsWithActors()
        {
            var displayMovieInfo = database.MoviesCollections.GroupJoin(database.RatingCollection,
                                                          movies => movies.MovieID,
                                                          rating => rating.MovieId,
                                                          (movies, rating) => new
                                                          {
                                                              movieId = movies.MovieID,
                                                              movieName = movies.Title,
                                                              budget = movies.Budget,
                                                              releaseYear = movies.ReleaseYear,
                                                              ratings = rating.Select(x => x.Stars)
                                                          })
                                                          .GroupJoin(database.ActorsCollection,
                                                          movierating => movierating.movieId,
                                                          actors => actors.MovieId,
                                                          (movierating, actors) => new
                                                          {
                                                              movierating,
                                                              actorId = actors.Select(x => x.ActorId)
                                                          });
                                                          

            foreach (var movie in displayMovieInfo)
            {
                var names = database.Actors.Where(x => movie.actorId.Contains(x.ActorId)).Select(x => x.Name).ToList();
                Console.WriteLine($"Movie Id: {movie.movierating.movieId}, Movie Name: {movie.movierating.movieName}, Movie Budget: {movie.movierating.budget}" +
                                  $" Release Year: {movie.movierating.releaseYear}, Names: {string.Join(", ", names)} Ratings: {string.Join(", ", movie.movierating.ratings)} ");
            }
        }
    }
}
