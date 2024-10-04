using MovieArrayLayer.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//presentation layer
namespace MovieArrayLayer.Presentation
{
    internal class Menu
    {
        public static MovieManager movieManager = new MovieManager();  

        public static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine("\n Simple Movies App Menu:");
                Console.WriteLine("1. Display Movies:");
                Console.WriteLine("2. Add Movie:");
                Console.WriteLine("3. Clear All Movies:");
                Console.WriteLine("4. Exit");

                Console.WriteLine("Enter Choice");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        DisplayMovies();
                        break;
                    case 2:
                        AddMovie();
                        break;
                    case 3:
                        ClearAllMovies();
                        break;
                    case 4:
                        Exit();
                        return;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
        private static void DisplayMovies()  //public
        {
            var movies = movieManager.GetMovies();
            if (movies.Count == 0)
            {
                Console.WriteLine("No Movies Available");
                return;
            }
            Console.WriteLine("Movies");
            for (int i = 0; i < movies.Count; i++)
            {
                var movie = movies[i];
                Console.WriteLine($"{i + 1}.{movie.MovieId} , {movie.Name} , {movie.Genre} , {movie.Year}");
            }
        }
        private static void AddMovie() //public
        {
            Console.WriteLine("Enter movie details:");

            Console.WriteLine("Movie ID:");
            int id=int.Parse(Console.ReadLine());

            Console.WriteLine("Movie Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Movie Genre:");
            string genre = Console.ReadLine();

            Console.WriteLine("Movie Year:");
            int year = int.Parse(Console.ReadLine());

            string result = movieManager.AddMovie(id, name, genre, year);
            Console.WriteLine(result);
        }
        private static void ClearAllMovies() //public
        {
            string result = movieManager.ClearAllMovies();
            Console.WriteLine(result);
        }
        private static void Exit()
        {
            Console.WriteLine("Exiting the application. Goodbye!");
            Environment.Exit(0);
        }
    }
}
    

