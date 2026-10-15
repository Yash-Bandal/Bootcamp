using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using IMDBConsoleApp.Data;
using IMDBConsoleApp.Exceptions;
using IMDBConsoleApp.Models;
using IMDBConsoleApp.Services;

namespace IMDBConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("IMDB Console App");

            MovieService movieService = new MovieService();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. List Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Show LINQ Menu");
                Console.WriteLine("4. Exit ");

                Console.WriteLine("Choose Option: ");

                if (!int.TryParse(Console.ReadLine().Trim(), out int choice))
                {
                    Console.WriteLine("Invalid Input, Enter a number ");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            List<Movie> movies = movieService.GetMovies();
                            ListMovies(movies);
                            break;

                        case 2:
                            AddMovie(movieService);
                            break;

                        case 3:
                            ShowLINQMenu(movieService);
                            break;

                        case 4:
                            return;

                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                catch (InvalidMovieException E)
                {
                    Console.WriteLine($"Validation Error! : {E.Message}");
                }
            }
        }

        // Services 
        public static void ListMovies(List<Movie> movies)
        {

            if (!movies.Any())
            {
                Console.WriteLine("No Movies Available Currently!. \n");
                return;
            }

            var movieDetails = movies.Select(movieItem =>
                $"Movie Name : {movieItem.Name}\n" +
                $"Year : {movieItem.YearOfRelease}\n" +
                $"Plot : {movieItem.Plot}\n" +
                $"Actors : {string.Join(", ", movieItem.Actors.Select(actor => actor.Name))}\n" +
                $"Producers : {movieItem.Producer.Name}\n" +
                "---------------------------------------"
            );

            Console.WriteLine(string.Join("\n", movieDetails));
        }

        public static void AddMovie(MovieService movieService)
        {
            // 1. Take Input

            // Moviename
            Console.Write("Enter Movie Name : ");
            var movieName = Console.ReadLine();

            // Year of Release
            Console.Write("Enter Year of Release : ");

            bool isValidYear = int.TryParse(
                Console.ReadLine().Trim(),
                out int yearOfRelease
            );

            if (!isValidYear)
            {
                throw new InvalidMovieException("Hey, Year is not a number");
            }

            // Plot
            Console.Write("Enter Movie Plot : ");
            var plot = Console.ReadLine();

            //  Actors
            var actors = movieService.GetActors();

            Console.WriteLine("Select Actors (Comma Seperated IDs) : ");

            Console.WriteLine(
                string.Join("\n", actors.Select(a => $"{a.Id}. {a.Name}"))
            );

            var actorInput = Console.ReadLine();

            var actorIds = actorInput
                .Split(',')
                .Select(id =>
                {
                    if (!int.TryParse(id.Trim(), out int parseId))
                    {
                        throw new InvalidMovieException("Invalid Actor ID Format");
                    }
                    return parseId;
                })
                .ToList(); //1, 2 ,3 => [1,2,3]

            var invalidActorIds = actorIds
                .Where(id => !movieService.GetActors().Any(a => a.Id == id))
                .ToList();

            // check invalid ids
            if (invalidActorIds.Any())
            {
                throw new InvalidMovieException("Extra IDs are invalid.");
            }

            var selectedActors = movieService.GetActors()
                .Where(actor => actorIds.Contains(actor.Id))
                .ToList();

            if (!selectedActors.Any())
            {
                throw new InvalidMovieException("No valid actors selected");
            }

            // producer

            Console.WriteLine("Select Producer (Any One)");

            Console.WriteLine(
                string.Join("\n", movieService.GetProducers().Select(p => $"{p.Id}. {p.Name}"))
            );

            if (!int.TryParse(Console.ReadLine().Trim(), out int producerId))
            {
                throw new InvalidMovieException("Producer ID must be a Integer number");
            }

            var selectedProducer = movieService.GetProducers().FirstOrDefault(p => p.Id == producerId);

            if (selectedProducer == null)
            {
                throw new InvalidMovieException("Invaluid");
            }

            // 2. Initialize movie object
            Movie movie = new Movie
            {
                Name = movieName,
                YearOfRelease = yearOfRelease,
                Plot = plot,
                Actors = selectedActors,
                Producer = selectedProducer,
            };

            // 3. Add
            movieService.AddMovieMain(movie);

            Console.WriteLine("Movie Added Successfully");
            Console.WriteLine("---------------------------------------");
        }

        public static void ShowLINQMenu(MovieService movieService)
        {
            if (!movieService.GetMovies().Any())
            {
                Console.WriteLine("No movie found");
                return;
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("LINQ Queries :");
                Console.WriteLine("1. Movies After 2010");
                Console.WriteLine("2. Movies by James Cameron");
                Console.WriteLine("3. Movie Names and years");
                Console.WriteLine("4. First Avatar movie");
                Console.WriteLine("5. Movies with Will Smith");
                Console.WriteLine("0. Back");

                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        PrintResult(movieService.MoviesAfter2010(), "Movies after 2010. ");
                        break;
                    case 2:
                        PrintResult(movieService.MoviesByJamesCameron(), "Movies By James Cameron. ");  
                        break;
                    case 3:
                        PrintResult(movieService.MovieNamesAndYears(), "All Movies with Year of Release ");
                        break;
                    case 4:
                        Console.WriteLine(movieService.FirstAvatarMovie() != null ? $"First Avatar Movie : {movieService.FirstAvatarMovie()}" : "No Avatar Movie Found. ");
                        break;
                    case 5:
                        PrintResult(movieService.MoviesWithWillSmith(), "Movies with Will Smith");
                         break;
                    case 0: 
                        return; //exit

                    default: Console.WriteLine("Invalid Choice"); 
                        break;
                }
            }
        }

        public static void PrintResult(List<string> data, string title)
        {
            Console.WriteLine($"\n -------{title}------- ");

            if (!data.Any())
            {
                Console.WriteLine("No Data Found. \n");
                return;
            }

            Console.WriteLine(string.Join("\n", data));
            //data.ToList().ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
        }

    }
}
