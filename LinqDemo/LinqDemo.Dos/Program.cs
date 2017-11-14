using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of planets so we can practice querying it 
            List<Planet> planets = Planet.GetList();

            // List all the planets, so we can see that our list is OK
            Console.WriteLine("List all of the planet names");
            foreach (Planet p in planets)
            {
                Console.Write(p.Name + ", ");
            }

            // Try out a LINQ query with a where clause, then show the results
            Console.WriteLine("List the planets within 200 million km of the sun");
            IEnumerable<String> innerPlanets = from p in planets where p.DistanceToSun < 200 select p.Name;
            foreach (String s in innerPlanets)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            // Use a scaler operator on a LINQ query
            Console.WriteLine("Our solar system has {0} planets", 
                              (from p in planets select p).Count()
                             );

            // Try a LINQ query with a lambda experssions
            Console.WriteLine("Same query, but with a lambda expression");
            innerPlanets = planets.Where(p => p.DistanceToSun < 200).Select(p => p.Name);
            foreach (String s in innerPlanets)
            {
                Console.Write(s + " ");
            }
        }
    }
}
