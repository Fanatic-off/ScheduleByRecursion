using MovieTheaterShowSchedule;
using System;
using System.Collections.Generic;

namespace MovieTheaterShowSchedule
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieTheater theater = new MovieTheater(500);
            MovieTheater.FilmsTime = new List<int>() { 90, 120, 60 };
            theater.CreateMovieGraph();
            theater.WriteLeavesGraph();

            Schedule schedule = theater.GetResult();
            foreach (int w in schedule.CurrentMovie)
            {
                Console.Write(w + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Свободного времени осталось {schedule.TimeWork}");

        }
    }
}
