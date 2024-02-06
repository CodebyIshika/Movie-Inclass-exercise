using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieExercise
{
    internal class Database
    {
        public List<Movie> MoviesCollections = new List<Movie>()
        {
            new Movie() { MovieID = 1, Title = "Shershaah", Budget = 200000, Category = "Thriller", ReleaseYear = 2022},
            new Movie() { MovieID = 2, Title = "Om Shanti Om", Budget = 100000, Category = "Drama", ReleaseYear = 1995},
            new Movie() { MovieID = 3, Title = "Yeh Jawaani Hai Deewani", Budget = 300000, Category = "Comedy", ReleaseYear = 2012},
            new Movie() { MovieID = 4, Title = "Bahubali", Budget = 1000000, Category = "Thriller", ReleaseYear = 2019},
            new Movie() { MovieID = 5, Title = "RRR", Budget = 500000, Category = "Action", ReleaseYear = 2023},
            new Movie() { MovieID = 6, Title = "Reacher", Budget = 600000, Category = "Action", ReleaseYear = 2023},
        };

        // many to many relation between actors and movies
        public List<MovieActors> ActorsCollection = new List<MovieActors>()
        { 
            new MovieActors() { MovieId = 1, ActorId = 1001 },
            new MovieActors() { MovieId = 2, ActorId = 1002 },
            new MovieActors() { MovieId = 2, ActorId = 1003 },
            new MovieActors() { MovieId = 3, ActorId = 1003 },
            new MovieActors() { MovieId = 3, ActorId = 1001 },
            new MovieActors() { MovieId = 4, ActorId = 1004 },
            new MovieActors() { MovieId = 5, ActorId = 1005 },
            new MovieActors() { MovieId = 6, ActorId = 1006 },
            //new MovieActors() { MovieId = 6, ActorId = 1005 },
        };

        public List<Actor> Actors = new List<Actor>()
        {
            new Actor() { ActorId = 1001, Name = "Sidharth Malhotra", Salary = 25000},
            new Actor() { ActorId = 1002, Name = "Shahrukh Khan", Salary = 50000},
            new Actor() { ActorId = 1003, Name = "Ranbir Kapoor", Salary = 35000},
            new Actor() { ActorId = 1004, Name = "Prabhas", Salary = 65000},
            new Actor() { ActorId = 1005, Name = "Ram Charan", Salary = 55000},
            new Actor() { ActorId = 1006, Name = "Tom Cruise", Salary = 85000},

        };

        public List<Rating> RatingCollection = new List<Rating>()
        {
            new Rating() { MovieId = 1, Stars = 4 },
            new Rating() { MovieId = 1, Stars = 5 },
            new Rating() { MovieId = 1, Stars = 5 },
            new Rating() { MovieId = 2, Stars = 3 },
            new Rating() { MovieId = 2, Stars = 5 },
            new Rating() { MovieId = 3, Stars = 4 },
            new Rating() { MovieId = 4, Stars = 5 },
            new Rating() { MovieId = 4, Stars = 4 },
            new Rating() { MovieId = 5, Stars = 3 },
            new Rating() { MovieId = 5, Stars = 4 },
            new Rating() { MovieId = 6, Stars = 5 },
            new Rating() { MovieId = 6, Stars = 4 },

        };

    }
}
