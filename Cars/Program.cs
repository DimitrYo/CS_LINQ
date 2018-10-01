using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Cars {
    class Program {
        static void Main(string[] args) {

            //

            //Func<int, int> square = x => x * x;
            //Expression<Func<int, int, int>> add = (x, y) => x + y;
            //Func<int, int, int> addI = add.Compile();

            //var result = addI(3, 5);
            //Console.WriteLine(result);
            //Console.WriteLine(add);

            //


            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());
            InsertData();
            QueryData();


            //CreateXml();
            //QueryXml();

            //foreach (var record in records) {

            //    var car = new XElement("Car",
            //        new XAttribute("Name", record.Name),
            //        new XAttribute("Combined", record.Combined),
            //        new XAttribute("Manufacturer",record.Manufacturer)
            //        );

            //    cars.Add(car);
            //}

            //document.Add(cars);
            //document.Save("fuel.xml");


            //var cars = ProcessFile("fuel.csv");
            //var manufacturers = ProccessManufacturers("manufacturers.csv");


            //var query6 =
            //    cars.GroupBy(c => c.Manufacturer)
            //    .Select(g => {
            //        var results = g.Aggregate(new CarStatistics(),
            //             (acc, c) => acc.Accumulate(c),
            //             acc => acc.Compute());

            //        return new {
            //            Name = g.Key,
            //            Avg = results.Average,
            //            Min = results.Min,
            //            Max = results.Max
            //        };
            //    })
            //    .OrderByDescending(r => r.Max);



            //var query6 =
            //    from car in cars
            //    group car by car.Manufacturer into carGroup
            //    select new {
            //        Name = carGroup.Key,
            //        Max = carGroup.Max(c => c.Combined),
            //        Min = carGroup.Min(c => c.Combined),
            //        Avg = carGroup.Average(c => c.Combined)
            //    } into result
            //    orderby result.Max descending
            //    select result;

            //foreach (var result in query6) {
            //    Console.WriteLine($"{result.Name}");
            //    Console.WriteLine($"\t Max: {result.Max}");
            //    Console.WriteLine($"\t Min: {result.Min}");
            //    Console.WriteLine($"\t Avg: {result.Avg}");
            //}






            //var query5 =
            //    manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new {
            //        Manufacturer = m,
            //        Cars = g
            //    }).GroupBy(m => m.Manufacturer.Headquarters);

            //var query5 =
            //    from manufacturer in manufacturers
            //    join car in cars on manufacturer.Name equals car.Manufacturer
            //    into carGroup
            //    select new {
            //        Manufacturer = manufacturer,
            //        Cars = carGroup
            //    } into result
            //    group result by result.Manufacturer.Headquarters;

            //foreach (var group in query5) {
            //    Console.WriteLine($"{group.Key}");


            //    foreach (var car in group.SelectMany(g => g.Cars)
            //                                .OrderByDescending(c => c.Combined)
            //                                .Take(3)) {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}


            //var query =
            //    manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new {
            //        Manufacturer = m,
            //        Cars = g
            //    }).OrderBy(m => m.Manufacturer.Name);

            //foreach (var group in query) {
            //    Console.WriteLine($"{group.Manufacturer.Name}:{group.Manufacturer.Headquarters}");
            //    foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2)) {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}





            //var query =
            //    from manufacturer in manufacturers
            //    join car in cars on manufacturer.Name equals car.Manufacturer
            //    into carGroup
            //    select new {
            //        Manufacturer = manufacturer,
            //        Cars = carGroup
            //    };

            //foreach (var group in query) {
            //    Console.WriteLine($"{group.Manufacturer.Name}:{group.Manufacturer.Headquarters}");
            //    foreach (var car in group.Cars.OrderByDescending(c => c.Combined).Take(2)) {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}






            //var query =
            //    from car in cars
            //    group car by car.Manufacturer.ToUpper() into manufacturer
            //    orderby manufacturer.Key
            //    select manufacturer;
            //var query2 =
            //    cars.GroupBy(c => c.Manufacturer.ToUpper())
            //    .OrderBy(g => g.Key);


            //foreach (var result in query) {
            //    Console.WriteLine($"{result.Key} has {result.Count()}");
            //}

            //foreach (var group in query2) {
            //    Console.WriteLine(group.Key);
            //    foreach (var car in group.OrderByDescending(c => c.Combined).Take(2)) {
            //        Console.WriteLine($"\t{car.Name} : {car.Combined}");
            //    }
            //}




            //var query = cars.OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name);

            //var query =
            //from car in cars
            //where car.Manufacturer == "BMW" && car.Year == 2016
            //orderby car.Combined descending, car.Name ascending
            //select new { // projection
            //    car.Manufacturer,
            //    car.Name,
            //    car.Combined
            //};


            //var query =
            //from car in cars
            //join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
            ////where car.Manufacturer == "BMW" && car.Year == 2016
            //orderby car.Combined descending, car.Name ascending
            //select new { // projection

            //    manufacturer.Headquarters,
            //    car.Name,
            //    car.Combined
            //};

            //var anon = new {
            //    Name = "Scott"
            //};

            //var query2 =
            //        cars.Join(manufacturers, c => c.Manufacturer, m => m.Name, (c, m) => new {
            //            m.Headquarters,
            //            c.Name,
            //            c.Combined
            //        }).OrderByDescending(c => c.Combined)
            //        .ThenBy(c => c.Name);

            //var query3 =
            //        cars.Join(manufacturers, c => c.Manufacturer, m => m.Name, (c, m) => new {
            //            Car = c,
            //            Manufacturer = m
            //        }).OrderByDescending(c => c.Car.Combined)
            //        .ThenBy(c => c.Car.Name);


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

            //var result = cars.SelectMany(c => c.Name)
            //    .OrderBy(c => c);

            //foreach (var name in result.Take(1)) {
            //    foreach (var character in name) {
            //        Console.WriteLine(character);
            //    }
            //}

            //foreach (var character in result) {
            //    Console.WriteLine(character);
            //}
            //Console.WriteLine(result);

            //foreach (var car in query.Take(10)) {
            //    Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
            //}

            //foreach (var car in query.Take(10)) {
            //    Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            //}

            //Console.WriteLine(Environment.NewLine);

            //foreach (var car in query2.Take(10)) {
            //    Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            //}
            //Console.ReadLine();

            //Console.WriteLine(Environment.NewLine);

            //foreach (var car in query3.Take(10)) {
            //    Console.WriteLine($"{car.Manufacturer.Headquarters} {car.Car.Name} : {car.Car.Combined}");
            //}
            //Console.ReadLine();
        }

        private static void QueryData() {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;


            var query =
                from car in db.Cars
                group car by car.Manufacturer into manufacturer
                select new {
                    Name = manufacturer.Key,
                    Cars = (from car in manufacturer
                            orderby car.Combined descending
                            select car)
                            .Take(2)
                };



            //var query =
            //    from car in db.Cars
            //    group car by car.Manufacturer into manufacturer
            //    select new {
            //        Name = manufacturer.Key,
            //        Cars = manufacturer.OrderByDescending(c => c.Combined).Take(2)
            //    };



            //var query = db.Cars
            //    .GroupBy(c => c.Manufacturer)
            //    .Select(g => new {
            //        Name = g.Key,
            //        Cars = g.OrderByDescending(c => c.Combined).Take(2)
            //    });

            foreach (var group in query) {
                Console.WriteLine(group.Name);
                foreach (var car in group.Cars) {
                    Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }



            //var query =
            //    from car in db.Cars
            //    orderby car.Combined descending, car.Name ascending
            //    select car;

            //var query = db.Cars
            //    .Where(c => c.Manufacturer == "BMW")
            //    .OrderByDescending(c => c.Combined)
            //    .ThenBy(c => c.Name)
            //    .Take(10)
            //    .ToList();
            //.Select(c => new { Name = c.Name.Split(' ') }); // not supported by entity framework


            //foreach (var item in query) {
            //    Console.WriteLine(item.Name);
            //}

            //Console.WriteLine(query.Count());

            //foreach (var car in query) {
            //    Console.WriteLine($"{car.Name} : {car.Combined}");
            //}
        }

        private static void InsertData() {
            var cars = ProcessFile("fuEl.csv");
            var db = new CarDb();

            if (!db.Cars.Any()) {

                foreach (var car in cars) {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }

        }

        private static void QueryXml() {

            var ns = (XNamespace)"htttp://pluralsight.com/cars/2016";
            var ex = (XNamespace)"htttp://pluralsight.com/cars/2016/ex";

            var document = XDocument.Load("fuel.xml");
            var query =
                from element in document.Element(ns + "Cars")?.Elements(ex + "Car") ?? Enumerable.Empty<XElement>()
                where element.Attribute("Manufacturer")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query) {
                Console.WriteLine(name);
            }

        }

        private static void CreateXml() {
            var records = ProcessFile("fuel.csv");

            var ns = (XNamespace)"htttp://pluralsight.com/cars/2016";
            var ex = (XNamespace)"htttp://pluralsight.com/cars/2016/ex";
            var document = new XDocument();
            var cars = new XElement(ns + "Cars",
                from record in records
                select new XElement(ex + "Car",
                    new XAttribute("Name", record.Name),
                    new XAttribute("Combined", record.Combined),
                    new XAttribute("Manufacturer", record.Manufacturer)
                    ));

            cars.Add(new XAttribute(XNamespace.Xmlns + "ex", ex));
            document.Add(cars);
            document.Save("fuel.xml");
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

        private static List<Manufacturer> ProccessManufacturers(string path) {

            var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l => {
                        var columns = l.Split(',');
                        return new Manufacturer {
                            Name = columns[0],
                            Headquarters = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    });
            return query.ToList();
        }


    }

    public class CarStatistics {

        public CarStatistics() {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }
        public int Max { get; set; }
        public int Min { get; set; }
        public double Average { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }

        internal CarStatistics Accumulate(Car car) {
            Total += car.Combined;
            Count += 1;
            Max = Math.Max(Max, car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }

        public CarStatistics Compute() {
            Average = Total / Count;
            return this;
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
