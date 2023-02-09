using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route_for_cities.Structure;

namespace Route_for_cities
{
    public class Helper
    {
        /* Задание.
         * Так же необходимо оценить функцию времени выполнения программы и возможность
         * ее оптимизации.
         *      Функция времени выполнения программы - чем больше входящих данных,
         * тем дольше выполняется программа.
         *      Добавила в программу "время выполнения программы" (будет выводиться на консоль
         * по завершению программы)
         *      Предложение: При больших объемах данных можно перевести логику на словари, 
         * оптимизируется время выполнения, добавить еще проверок.
         */

        #region ValidateNumOfRequest
        /// <summary>
        /// Validate number of the requests.
        /// </summary>
        /// <param name="str"></param>
        /// <returns>long num</returns>
        public long ValidateNumberOfRequests(string str)
        { 
            try
            {
                long num = Convert.ToInt64(str);
                if (num <= 0) 
                {
                    throw new ArgumentException();
                }
                else
                    return num;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Число должно быть больше 0");
                return 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверно указано количество запросов. Попробуйте снова");
                return 0;
            }
        }
        #endregion

        #region Validate city or path
        /// <summary>
        /// Validate stringname the city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>string[] cities</returns>
        public string[] ValidateCity(string city)
        {
            string[] cities;
            try
            {
                if (city == "" || city == " ")
                     throw new ArgumentException();
               
                cities = city.Split(' ');

                if (cities.Length != 2)
                    throw new FormatException();
                if (cities[0] == cities[1])
                    throw new Exception();

            }
            catch (ArgumentException)
            {
                Console.WriteLine("Неверно указаны города. Попробуйте снова.");
                return new string[0];
            }
            catch(FormatException) 
            {
                Console.WriteLine("Введено не два города. Попробуйте снова.");
                return new string[0];
            }
            catch(Exception) 
            {
                Console.WriteLine("Введено два одинаковых города или два пробела. Попробуйте снова.");
                return new string[0];
            }
            return cities;
        }
        /// <summary>
        /// Validate path the cities
        /// </summary>
        /// <param name="cities"></param>
        /// <returns></returns>
        public string ValidatePath(List<PathCity> cities)
        {
            bool NoError = true;
            var paths = cities.ToList();
            bool doublePath = false;
            
            for (int i = 0; i < paths.Count - 1; i++)
            {
                for (int j = i + 1; j < paths.Count; j++)
                {
                    if (paths[j].From == paths[i].From || paths[j].To == paths[i].To)
                    {
                        doublePath = true;
                        break;
                    }
                }
                if (doublePath)
                    break;
            }
            if (doublePath)
            {
                Console.WriteLine("В введенных данных - закольцованность. Попробуйте снова.");
                NoError = false;
            }
            bool gapPathFrom = false;
            bool gapPathTo = false;
            var citiesStartPathFrom = new List<string>();
            var citiesStartPathTo = new List<string>();

            for (int i = 0; i < paths.Count; i++)
            {
                gapPathFrom = false;
                gapPathTo= false;

                for (int j = 0; j < paths.Count; j++)
                {
                    if (paths[i].From == paths[j].To)
                        gapPathFrom = true;
                    if (paths[i].To == paths[j].From)
                         gapPathTo = true;
                }
                if (gapPathFrom == false)
                    citiesStartPathFrom.Add(paths[i].From);
                if (gapPathTo == false)
                    citiesStartPathTo.Add(paths[i].To);
            }
            if (citiesStartPathFrom.Count > 1 || citiesStartPathTo.Count > 1
                || citiesStartPathFrom.Count == 0 || citiesStartPathTo.Count == 0)
            {
                Console.WriteLine("Есть разрывы или закольцованность. Ошибка ввода данных по заданию.");
                NoError = false;
            }
            if (NoError == false)
            {
                return "ERRORR";
            }
            else {
                return citiesStartPathFrom[0];
            }
            
        }
        
        /// <summary>
        /// Validate city start path
        /// </summary>
        /// <param name="StartPath"></param>
        /// <param name="paths"></param>
        public void ValidateStartPath(string StartPath, List<PathCity> paths)
        {
            if (StartPath == "" || StartPath == null)
            {
                Console.WriteLine("Ошибка ввода данных.");
            }
            else
            {
                if (StartPath == "ERRORR")
                {
                    Console.WriteLine("Завершение работы");
                }
                else
                {
                    PrintCity(StartPath, paths);
                }

            }
        }
        #endregion

        #region Print cities
        /// <summary>
        /// Print a list of paths to the console
        /// </summary>
        /// <param name="StartPath"></param>
        /// <param name="cities"></param>
        public void PrintCity(string StartPath, List<PathCity> cities)
        {
            var paths = cities.ToList();
            Console.WriteLine();
            Console.Write($"Маршрут: {StartPath} ");
            for (int i = 0; i < paths.Count + 1; i++)
            {
                for (int j = 0; j < paths.Count; j++)
                {
                    if (paths[j].From == StartPath)
                    {
                        Console.Write($"{paths[j].To} ");
                        StartPath = paths[j].To;
                    }
                } 
            }
        }
        #endregion
    }
}
