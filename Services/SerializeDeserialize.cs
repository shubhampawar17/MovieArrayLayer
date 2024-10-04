using MovieArrayLayer.model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieArrayLayer.Services
{
    internal class SerializeDeserialize
    {
        public static string filePath = ConfigurationManager.AppSettings["myFilePath"]; 

        public static void SerializeMovies(List<Movie> movies)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movies));
            }
        }
        public static List<Movie> DeserializationMovies()
        {
            if (!File.Exists(filePath))
                return new List<Movie>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                var deserializedMovies = JsonSerializer.Deserialize<List<Movie>>(sr.ReadToEnd());
                return deserializedMovies ?? new List<Movie>();
            }
        }
    }
}
