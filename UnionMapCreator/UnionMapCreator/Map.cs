using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionMapCreator
{
    public class Map
    {
        public List<Continent> Continents {  get; set; }
        public List<Node> Territories { get; set; }

        public Map(List<Continent> someContinents, List<Node> someTerritories)
        {
            Continents = someContinents;
            Territories = someTerritories; 
        }
    }
}
