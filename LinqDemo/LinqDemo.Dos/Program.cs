using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo.Dos
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Planet> planets = new List<Planet> {
                new Planet{Name="Mercury", Diameter=4879, DistanceToSun=67},
                new Planet{Name="Venus", Diameter=12104, DistanceToSun=107},
                new Planet{Name="Earth", Diameter=12756, DistanceToSun=148},
                new Planet{Name="Mars", Diameter=6792, DistanceToSun=248},
                new Planet{Name="Jupiter", Diameter=142984, DistanceToSun=813},
                new Planet{Name="Saturn", Diameter=120536, DistanceToSun=1505},
                new Planet{Name="Uranus", Diameter=51118, DistanceToSun=2978},
                new Planet{Name="Neptune", Diameter=49528, DistanceToSun=4479}
            };
            
            Console.WriteLine("List all of the planet names");
            foreach (Planet p in planets)
            {
                Console.Write(p.Name + ", ");
            }

            Console.WriteLine("List the planets within 200 million km of the sun");
            IEnumerable<String> innerPlanets = from p in planets where p.DistanceToSun < 200 select p.Name;
            foreach (String s in innerPlanets)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Our solar system has {0} planets", 
                              (from p in planets select p).Count()
                             );
            
            Console.WriteLine("Same queries, but with lambda expressions");

            innerPlanets = planets.Where(p => p.DistanceToSun < 200).Select(p => p.Name);
            foreach (String s in innerPlanets)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }
    }
}
