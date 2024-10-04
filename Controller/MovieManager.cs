using MovieArrayLayer.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using MovieArrayLayer.Services;
//service layer
namespace MovieArrayLayer.Controller
{
    internal class MovieManager
    {
        public List<Movie> movies;
        public const int MaxMovies = 5;

        public MovieManager()
        {  
            movies = SerializeDeserialize.DeserializationMovies();
        }
        public List<Movie> GetMovies()
        {
            return movies;
        }
        public string AddMovie(int id, string name, string genre, int year)
        {
            if (movies.Count >= MaxMovies)
            {
                return "Movie list if full";
            }
            Movie movie = new Movie(id, name, genre, year);
            movies.Add(movie);
            SerializeDeserialize.SerializeMovies(movies);

            return "Movie added Successfully";

        }
        public string ClearAllMovies()
        {
            movies.Clear();
            SerializeDeserialize.SerializeMovies(movies);
            return "All movies clear";
        }
       
    }
}
    

