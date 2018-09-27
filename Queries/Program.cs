using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Queries {
    class Program {
        static void Main(string[] args) {

            var numbers = MyLinq.Random().Where(n => n > 0.5).Take(10);
            foreach (var number in numbers) {
                Console.WriteLine(number);
            }

            var movies = new List<Movie> {
                new Movie { Title = "The Dark Kniht", Rating = 8.9f, Year = 2008},
                new Movie { Title = "The King's Speech", Rating = 8.0f, Year = 2010},
                new Movie { Title = "Casablanca", Rating = 8.5f, Year = 1942},
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980}
            };
            var sw = new Stopwatch();

            //var query = movies.Where(m => m.Year > 2000);.
            //var query = movies.Filter(m => m.Year > 2000);
            //var query = movies.Where(m => m.Year > 2000);
            //var query = movies.Filter(m => m.Year > 2000);


            //sw.Start();
            //var query = movies.AsParallel().Where(m => m.Year > 2000);
            //var query = movies.Where(m => m.Year > 2000);
            //var query = movies.Filter2(m => m.Year > 2000);


            var query = movies.Filter(m => m.Year > 2000);

            //foreach (var movie in query) {
            //    Console.WriteLine(movie.Title);
            //}
            //sw.Stop();
            //Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.WriteLine(query.Count());
            var enumerator = query.GetEnumerator();
            while (enumerator.MoveNext()) {
                Console.WriteLine(enumerator.Current.Title);
            }

            Console.ReadLine();
        }
    }
}
