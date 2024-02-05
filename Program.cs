using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieAnalysis movieAnalysis = new MovieAnalysis();
            movieAnalysis.GetAllMoviesInCategory("Thriller");
            Console.WriteLine();
            movieAnalysis.GetCountInCategory("Comedy");
            Console.WriteLine();
            movieAnalysis.MoviesInBudget(500000);
            Console.WriteLine();
            movieAnalysis.MoviesInThe90s();
            Console.WriteLine();
            movieAnalysis.CalculateOverallRating("RRR", 2023);
            Console.WriteLine();
            movieAnalysis.HighestPaidSalary();
            Console.WriteLine();
            movieAnalysis.HighestPaidActor();
            Console.WriteLine();
            movieAnalysis.HighestPaidActorByOrder();
            Console.WriteLine();
            movieAnalysis.GetMovieDetails();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            movieAnalysis.GetExtendedMovieDetails();

            Console.WriteLine();
            Console.WriteLine(" All movie details with actors-----------");
            Console.WriteLine();
            movieAnalysis.GetMovieDetailsWithActors();


            Console.ReadKey();
        }
    }
}
