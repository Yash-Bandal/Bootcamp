using System;
using IMDBConsoleApp.Data;
using IMDBConsoleApp.Models;
using System.Collections.Generic;
using System.Linq;
using IMDBConsoleApp.Exceptions;

namespace IMDBConsoleApp.Services
{
    internal class MovieService
    {
        public List<Movie> MovieList = DataStore.Movies;
        public List<Actor> ActorList = DataStore.Actors;
        public List<Producer> ProducerList = DataStore.Producers;
     
        public void AddMovieMain(Movie movie)
        {

           ValidateMovie(movie);
           MovieList.Add(movie);
        }

        public List<Movie> GetMovies()
        {
            return MovieList;
        }

  
        public List<Actor> GetActors()
        {
            return ActorList;
        }
       
        public List<Producer> GetProducers()
        {
            return ProducerList;
        }

        // LINQ 
        public List<string> MoviesAfter2010()
        {
            var result = MovieList
                .Where(m => m.YearOfRelease > 2010)
                .Select(m => m.Name)
                .ToList();

            return result;

        }

        public List<string> MoviesByJamesCameron()
        {
            // Lambda/method  syntax
            var result = MovieList
                .Where(m => m.Producer.Name.ToLower() == "james cameron")
                .Select(m => m.Name).ToList();


            //query syntax - converted to method 
            //var result = from m in MovieList
            //             where m.Producer.Name.ToLower() == "james cameron"
            //             select m.Name;

            return result;

        }

        public List<string> MovieNamesAndYears()
        {
            var result = MovieList
                        .Select(m => $"{m.Name} : {m.YearOfRelease}").ToList();

            return result;
        }

        public string FirstAvatarMovie()
        {
            var movie = MovieList
                .FirstOrDefault(m => m.Name.ToLower().Contains("avatar"));

            return movie.Name;
        }

        public List<string> MoviesWithWillSmith()
        {
            var result = MovieList
                .Where(m => m.Actors.Any(a => a.Name.ToLower() == "will smith"))
                .Select(m => m.Name).ToList();

            return result;
        }

        private void ValidateMovie(Movie movie)
        {
       
            if (string.IsNullOrWhiteSpace(movie.Name))
                throw new InvalidMovieException("Movie Cannot be Empty.");

            if (movie.YearOfRelease < 1900)
                throw new InvalidMovieException("Movie Year cannot be before 1900s");

            if (string.IsNullOrWhiteSpace(movie.Plot))
                throw new InvalidMovieException("Movie plot cannot be empty.");

            if (movie.Actors == null || !movie.Actors.Any())
                throw new InvalidMovieException("At least one actor must be selected");

            if (movie.Producer == null)
                throw new InvalidMovieException("Producer must be seleted");

            // Duplicate movie check
            bool MovieExists = MovieList.Any(
                m => m.Name.ToLower() == movie.Name.ToLower() &&
                m.YearOfRelease == movie.YearOfRelease
                );

            if (MovieExists)
            {
                throw new InvalidMovieException("Movie Already Exists");
            }
        }
    }
}
