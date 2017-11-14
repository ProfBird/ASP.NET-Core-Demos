using System;
using System.Collections.Generic;
using System.Linq;
using LinqDemo.Dos;

namespace LinqExercise.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of planets so we can practice querying it 
            List<Planet> planets = Planet.GetList();

            /* Exercise 1a: 
             * Write a query to find all the planets greater than a certain size. 
             * Use a loop to display the name and size of each planet.
             */
            Console.WriteLine("List the planets bigger than the earth");
            IEnumerable<Planet> biggerPlanets = from p in planets 
                                                where p.Diameter > 12756 
                                                select p;
            
            foreach (Planet p in biggerPlanets)
            {
                Console.WriteLine(p.Name + ", " + p.Diameter + " km");
            }

            Console.WriteLine();

            /* Exercise 1b:
             * Write a query to search for "Earth".
             * Display the size and distance from the sun
             */
            Console.WriteLine("Info about my planet");
            Planet myPlanet = (from p in planets
                               where p.Name == "Earth"
                               select p).SingleOrDefault();
            
            Console.WriteLine("Name: " + myPlanet.Name + ", " +
                              "Diameter: " + myPlanet.Diameter + " km");
        }
    }
}
