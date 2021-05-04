using System;
using System.Collections.Generic;

namespace MovieTheaterShowSchedule
{
    public class MovieTheater
    {
        public int TimeWork = (24 - 10) * 60;
        public int Hall = 2;
        public List<string> Movie;
        public List<MovieTheater> Next;

        public MovieTheater()
        {

        }

        public void CreateMovieGraph(List<string> Movie, List<string> current)
        {
            if (current.Count == Hall)
            {
                foreach (string a in current)
                {
                    Console.Write(a + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (string a in Movie)
                {
                    List<string> temp = new List<string>();
                    foreach (string b in current)
                    {
                        temp.Add(b);
                    }
                    temp.Add(a);
                    CreateMovieGraph(Movie, temp);
                }
            }
        }
    }
}
