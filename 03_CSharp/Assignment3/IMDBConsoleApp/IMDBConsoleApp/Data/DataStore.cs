using IMDBConsoleApp.Models;
using System;
using System.Collections.Generic;


namespace IMDBConsoleApp.Data
{
    public static class DataStore
    {
        public static List<Actor> Actors = new List<Actor> 
        {
            new Actor { Id = 1, Name = "Tom Hanks"},
            new Actor { Id = 2, Name = "Will Smith"},
            new Actor { Id = 3, Name = "Cillian Murph"},
        };

        public static List<Producer> Producers = new List<Producer>
        {
           new Producer {  Id = 1, Name = "David Heyman" },
           new Producer {  Id = 2, Name = "Kevin Feige" },
           new Producer {  Id = 3, Name = "James Cameron" },
        };
       
        public static List<Movie> Movies = new List<Movie>();
    }
}
