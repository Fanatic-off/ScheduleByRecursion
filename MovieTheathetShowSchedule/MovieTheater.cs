using System;
using System.Collections.Generic;

namespace MovieTheaterShowSchedule
{
    public class MovieTheater
    {
        public static List<int> FilmsTime;
        public int TimeWork = (24 - 10) * 60;
        public int Hall = 2;
        public List<int> CurrentMovie;
        public List<MovieTheater> Next;

        public MovieTheater(int timeWork = (24 - 10) * 60, List<int> current = null)
        {
            this.TimeWork = timeWork;

            if (current != null)
            {
                CurrentMovie = current;
            }
            else
            {
                CurrentMovie = new List<int>();
            }

            Next = new List<MovieTheater>();
        }

        public void CreateMovieGraph()
        {
            foreach (int films in FilmsTime)
            {
                if (films <= TimeWork)
                {
                    List<int> temp = new List<int>();
                    foreach (int current in CurrentMovie)
                    {
                        temp.Add(current);
                    }
                    temp.Add(films);
                    MovieTheater theater = new MovieTheater(TimeWork - films, temp);

                    Next.Add(theater);
                    theater.CreateMovieGraph();
                }
            }
        }
        public void WriteLeavesGraph()
        {
            if (Next.Count == 0)
            {
                foreach (int s in CurrentMovie)
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

        public Schedule GetResult()
        {
            if (Next.Count == 0)
            {
                return new Schedule(TimeWork, CurrentMovie);
            }
            else
            {
                List<Schedule> results = new List<Schedule>();
                foreach (MovieTheater s in Next)
                {
                    results.Add(s.GetResult());
                }

                Schedule minResult = results[0];
                foreach (Schedule q in results)
                {
                    if (minResult.TimeWork > q.TimeWork)
                    {
                        minResult = q;
                    }
                }
                return minResult;
            }
        }
    }

    public class Schedule
    {
        public int TimeWork;
        public List<int> CurrentMovie;

        public Schedule(int timeWork, List<int> currentMovie)
        {
            TimeWork = timeWork;
            CurrentMovie = currentMovie;
        }
    }
}
