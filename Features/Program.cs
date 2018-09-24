using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Features.Linq;

namespace Features {
    class Program {
        static void Main(string[] args) {

            IEnumerable<Employee> developers = new Employee[] {
                new Employee { Id = 1, Name = "Scott"},
                new Employee { Id = 2, Name = "Chris"}
            };

            IEnumerable<Employee> sales = new List<Employee>() {
                new Employee { Id = 3, Name = "Alex"}
            };

            //foreach (var person in sales) {
            //    Console.WriteLine(person.Name);
            //}

            //Console.WriteLine(sales.Count());
            //Console.WriteLine(

            //var enumerator = sales.GetEnumerator();
            //while (enumerator.MoveNext()) {
            //    Console.WriteLine(enumerator.Current.Name);

            //}

            //foreach (var employee in developers.Where(NameStartsWithS)) {
            //    Console.WriteLine(employee.Name);
            //}
            //Console.ReadLine();

            //foreach (var employee in developers.Where(
            //    delegate (Employee employee) {
            //        return employee.Name.StartsWith("S");})) {
            //    Console.WriteLine(employee.Name);
            //}
            //Console.ReadLine();

            Func<int, int> f = Square;
            Console.WriteLine(f(2));
            Func<int, int> square = x => x * x;
            Console.WriteLine(square(2));
            Func<int, int, int> add = (x, y) => x + y;
            Console.WriteLine(add(2, 3));

            Action<int> write = x => Console.WriteLine(x);
            write(square(add(3, 5)));

            //foreach (var employee in developers.Where(e => e.Name.StartsWith("S"))) {
            //    Console.WriteLine(employee.Name);
            //}

            foreach (var employee in developers
                .Where(e => e.Name.Length == 5)
                .OrderBy(e => e.Name)
                ) {
                Console.WriteLine(employee.Name);
            }

            Console.ReadLine();
        }

        private static int Square(int x) {
            return x * x;
        }

        private static bool NameStartsWithS(Employee employee) {
            return employee.Name.StartsWith("S");
        }
    }
}
