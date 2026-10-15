using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace IMDBConsoleApp.Exceptions
{
    public class InvalidMovieException : Exception
    {
        public InvalidMovieException(string message) : base(message)
        {
            
        }
    }
}
