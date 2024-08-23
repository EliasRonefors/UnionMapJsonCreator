using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionMapCreator
{
    public class Node
    {
        public string name { get; set; }
        public List<string> continentList = new List<string>();
        public List<string> adjecentList = new List<string>();
        public readonly PointF position;

        public string[] continentNames {  get; set; }
        public string[] adjecentNames { get; set; }

        public Node(string name, PointF position) 
        { 
            this.name = name;
            this.position = position;
        }
    }
}
