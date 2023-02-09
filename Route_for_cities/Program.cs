using Route_for_cities.Structure;
using System.Diagnostics;

namespace Route_for_cities
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            //Create an instance of a class
            Helper helper = new Helper();
            
            long num = 0;
            while (num <= 0) 
            { 
            Console.WriteLine("Введите количество запросов");
            // Validate the number of requests
            num = helper.ValidateNumberOfRequests(Console.ReadLine());
            }

            //Сreate a list of paths
            List<PathCity> paths = new List<PathCity>();
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Введите города через пробел");
                //Validate the city
                string[] cities = helper.ValidateCity(Console.ReadLine());
                if (cities.Length < 2)
                {
                    Console.WriteLine("Работа прекращена");
                    break;
                }
                //Сreate Path of the city
                else
                    paths.Add(new PathCity(cities[0], cities[1]));
            }
            if (paths.Count > 0)
            {
                //Validate correct the path
                var StartPath = helper.ValidatePath(paths);
                //Validate the path and Print path for city
                helper.ValidateStartPath(StartPath, paths);
            }
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine($"Время выполнения программы: {sw.Elapsed}");


        }
        
    }
}