using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {

            // ========================

            var months = new string[12] { "June", "July", "August", "September", "October", "November", "December", "January", "February", "March", "April", "May" };

            int n = 4;
            var monthsWithLength = from x in months
                                   where x.Length == n
                                   select x;
            foreach (var word in monthsWithLength)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            var monthsSummerAndWinter = months.Take(3).Union(months.Skip(6).Take(3));


            foreach (var word in monthsSummerAndWinter)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            var monthsSorted = from x in months
                               orderby x
                               select x;

            foreach (var word in monthsSorted)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            var monthsWithLetterAndLength = (from x in months where x.Length >= 4 select x).Intersect(from x in months where x.Contains('u') select x);

            foreach (var word in monthsWithLetterAndLength)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            // ========================

            var cars = new List<Car>();
            cars.Add(new Car(0, "Tesla", "S", 2020, 200, "AAAA0", "red"));
            cars.Add(new Car(1, "Tesla", "X", 2015, 100, "AAAA1", "red"));
            cars.Add(new Car(2, "Tesla", "Y", 2017, 150, "AAAA2", "blue"));
            cars.Add(new Car(3, "Volvo", "XC90", 2020, 80, "AAAA3", "red"));
            cars.Add(new Car(4, "Volvo", "XC60", 2019, 50, "AAAA4", "red"));
            cars.Add(new Car(5, "ImagineCars", "ImaginableModel1", 2016, 50, "AAAA5", "blue"));
            cars.Add(new Car(6, "ImagineCars", "ImaginableModel1", 2017, 55, "AAAA6", "rainbow"));
            cars.Add(new Car(7, "ImagineCars", "ImaginableModel1", 2018, 60, "AAAA7", "rainbow"));
            cars.Add(new Car(8, "ImagineCars", "ImaginableModel2", 2019, 150, "AAAA8", "red"));


            var carsOfBrand = cars.Where(x => x.Brand == "Tesla");

            foreach (var car in carsOfBrand)
            {
                Console.Write(car + " ");
            }
            Console.WriteLine();

            var model = "ImaginableModel1";
            var carsOfModelAndAge = (cars.Where(x => x.Model == model)).Intersect(cars.Where(x => x.Age > 2));
            foreach (var car in carsOfModelAndAge)
            {
                Console.Write(car + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var carsOfColorAndPrice = (cars.Where(x => x.Color == "red")).Intersect(cars.Where(x => x.Price > 60 && x.Price < 150)).Count();
            Console.WriteLine("Cars of red (60,150)$: " + carsOfColorAndPrice);
            Console.WriteLine("First Oldest Car: " + cars.Where(x => x.Production_year == cars.Min(x => x.Production_year)).First());
            var newestCars = cars.OrderBy(x => x.Age).Take(5);
            foreach (var car in newestCars)
            {
                Console.Write(car + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var carsSortedByPirce = cars.OrderBy(x => x.Price);
            foreach (var car in carsSortedByPirce)
            {
                Console.Write(car + " | ");
            }
            Console.WriteLine();
            Console.WriteLine();

            var task4 = (((from x in months where x.Length > 3 select x)).Skip(3).
                           Intersect(from x in months where x.Contains("u") select x)).
                           Count();



            var log = new LogRecord[]
            {

                    new LogRecord("Action 1",       "Action"),
                    new LogRecord("Action 2",       "Action"),
                    new LogRecord("Event 1",        "Event"),
                    new LogRecord("Exception 1",    "Exception"),
                    new LogRecord("Exception 2",    "Exception"),
                    new LogRecord("Error 1",        "Error"),
                    new LogRecord("Error 2",        "Error")
            };

            var attentionLevel = new AttentionLevel[]
                {
                    new AttentionLevel ((LogType)0, "Regular"),
                    new AttentionLevel ((LogType)1, "Regular"),
                    new AttentionLevel ((LogType)2, "Warning"),
                    new AttentionLevel ((LogType)3, "Error"),
                
                };


            var mergedLog = log.Join(attentionLevel, a => a.type, b => b.type, (a,b) => new { attentionLevel = b.level, desc = a.desc } );


            foreach (var elem in mergedLog)
            {
                Console.WriteLine(string.Format("[{0}] {1}", elem.attentionLevel, elem.desc));
            }
            Console.WriteLine();




        }
        public enum LogType
        {
            Action,
            Event,
            Exception,
            Error
        }
        public class LogRecord
        {
            public string desc;
            public LogType type;

            public LogRecord(string arg_desc, LogType arg_type) => (desc, type) = (arg_desc, arg_type);
            public LogRecord(string arg_desc, string arg_type) : this(arg_desc, (LogType)Enum.Parse(typeof(LogType), arg_type)) { }
            // Крайне необычно
        };

        public class AttentionLevel
        {

            public LogType type;
            public string level;

            public AttentionLevel(LogType arg_type, string arg_level) => (level, type) = (arg_level, arg_type);
        }

    }
}
