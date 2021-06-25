using System.Collections.Generic;

namespace Graph_API_Visualizer.Models
{
    public class Graph
    {
        public int Id { get; set; }
        public List<Node> Nodes { get; set; }
        public bool Edges { get; set; }
    }
}

