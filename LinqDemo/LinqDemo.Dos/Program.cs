using System;
using System.Collections.Generic;

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
                new Planet{Name="Mars", Diameter=6792, DistanceToSun=248}
                new Planet{Name="Jupiter", Diameter=142984, DistanceToSun=813},
                new Planet{Name="Saturn", Diameter=120536, DistanceToSun=1505},
                new Planet{Name="Uranus", Diameter=51118, DistanceToSun=2978},
                new Planet{Name="Neptune", Diameter=49528, DistanceToSun=4479}
            };
            
            // List the planets
            foreach (Planet p in planets)
            {
                Console.Write(p.Name + ", ");
            }
        }
    }
}
