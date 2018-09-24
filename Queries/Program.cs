using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries {
    class Program {
        static void Main(string[] args) {


            var movies = new List<Movie> {
                new Movie { Title = "The Dark Kniht", Rating = 8.9f, Year = 2008},
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2008},
                new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1992},
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1992}
            };

            //var query = movies.Where(m => m.Year > 2000);.
            var query = movies.Filter(m => m.Year > 2000);

            foreach (var movie in query) {
                Console.WriteLine(movie.Title);
            }

            Console.ReadLine();
        }
    }
}
