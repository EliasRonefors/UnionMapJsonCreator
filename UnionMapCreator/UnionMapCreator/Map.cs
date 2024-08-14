using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionMapCreator
{
    public class Map
    {
        public List<Continent> continents {  get; set; }
        public List<Node> territories { get; set; }

        public Map(List<Continent> continents, List<Node> territories)
        {
            this.continents = continents;
            this.territories = territories; 
        }
    }
}
