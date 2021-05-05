using System;
using System.Collections.Generic;

namespace MovieTheaterShowSchedule
{
    public class MovieTheater
    {
        public int TimeWork = (24 - 10) * 60;
        public int Hall = 2;
        public int TimeMovie = 190;
        public static List<string> Movie;
        public List<string> CurrentMovie;
        public List<MovieTheater> Next;

        public MovieTheater(int timeWork = (24 - 10) * 60, List<string> current = null)
        {
            TimeWork = timeWork;

            if (current != null)
            {
                CurrentMovie = current;
            }
            else
            {
                CurrentMovie = new List<string>();
            }

            Next = new List<MovieTheater>();
        }

        public void CreateMovieGraph()
        {
            foreach (string movie in Movie)
            {
                if (TimeWork - TimeMovie > 0)
                {
                    List<string> temp = new List<string>();
                    foreach (string m in CurrentMovie)
                    {
                        temp.Add(m);
                    }
                    temp.Add(movie);
                    MovieTheater theater = new MovieTheater(TimeWork - TimeMovie, temp);

                    Next.Add(theater);
                    theater.CreateMovieGraph();
                }
            }
            //if (current.Count == Hall)
            //{
            //    foreach (string a in current)
            //    {
            //        Console.Write(a + " ");
            //    }
            //    Console.WriteLine();
            //}
            //else
            //{
            //    foreach (string a in Movie)
            //    {
            //        List<string> temp = new List<string>();
            //        foreach (string b in current)
            //        {
            //            temp.Add(b);
            //        }
            //        temp.Add(a);
            //        CreateMovieGraph(Movie, temp);
            //    }
            //}
        }

        public void WriteLeavesGraph()
        {
            if (Next.Count == 0)
            {
                foreach (string s in CurrentMovie)
                {
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (MovieTheater m in Next)
                {
                    m.WriteLeavesGraph();
                }
            }
        }
    }

    public class Schedule
    {
        public int TimeWork;
        public List<string> CurrentMovie;

        public Schedule(int timeWork, List<string> currentMovie)
        {
            TimeWork = timeWork;
            CurrentMovie = currentMovie;
        }
    }

}
