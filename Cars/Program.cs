using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars {
    class Program {
        static void Main(string[] args) {
            var cars = ProcessFile("fuel.csv");
            //var query = cars.OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name);

            var query =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select new { // projection
                    car.Manufacturer,
                    car.Name,
                    car.Combined
                };

            var anon = new {
                Name = "Scott"
            };

            //var top =
            //        cars
            //        .OrderByDescending(c => c.Combined)
            //        .ThenBy(c => c.Name)
            //        .Select(c => c)
            //        .FirstOrDefault(c => c.Manufacturer == "BMW" && c.Year == 2016);

            //if (top != null) {
            //    Console.WriteLine(top.Name);
            //}

            //var result = cars.Any(c => c.Manufacturer == "Ford");

            var result = cars.SelectMany(c => c.Name)
                .OrderBy(c => c);

            //foreach (var name in result.Take(1)) {
            //    foreach (var character in name) {
            //        Console.WriteLine(character);
            //    }
            //}

            foreach (var character in result) {
                Console.WriteLine(character);
            }
            //Console.WriteLine(result);

            //foreach (var car in query.Take(10)) {
            //    Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            //}
            Console.ReadLine();
        }

        private static List<Car> ProcessFile(string path) {
            var query =
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ToCar();

            return query.ToList();

            //.Select(Car.ParseFromCsv)
            //.ToList();

            //var query = from line in File.ReadAllLines(path).Skip(1)
            //where line.Length > 1
            //select Car.ParseFromCsv(line)

            //return query.ToList()
        }


    }
    public static class CarExtensions {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source) {

            foreach (var line in source) {

                var columns = line.Split(',');

                yield return new Car {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3].Replace('.', ',')),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }

        }
    }
}
