using IMDBConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBConsoleApp.Models
{
    public class Movie
    {
        public int YearOfRelease { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public List<Actor> Actors { get; set; } = new List<Actor>();
        public Producer Producer { get; set; }
    }
}
