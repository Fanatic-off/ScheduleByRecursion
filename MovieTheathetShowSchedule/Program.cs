using MovieTheaterShowSchedule;
using System;
using System.Collections.Generic;

namespace MovieTheaterShowSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            //MovieTheater theater = new MovieTheater();
            //theater.CreateMovieGraph(new List<string>() { "Властелин", "Хоббит" }, new List<string>());
            MovieTheater.Movie = new List<string>() { "MMM"};
            MovieTheater theater = new MovieTheater();
            theater.CreateMovieGraph();
        }
    }
}
