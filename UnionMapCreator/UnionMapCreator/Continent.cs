using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionMapCreator
{
    public class Continent
    {
        public string name { get; set; }
        public int troopBonus { get; set; }

        public Continent(string name, int troopBonus)
        {
            this.name = name;
            this.troopBonus = troopBonus;
        }
    }
}
