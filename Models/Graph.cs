using System.Collections.Generic;

namespace Graph_API_Visualizer.Models
{   
    /// <summary>
    /// The  Graph class.
    /// Contains all methods to define the Graph
    /// </summary>
    /// <remarks>
    /// This class can set and get de attributes to the Graph object
    /// </remarks>
    public class Graph
    {
        public int Id { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Edges> Edges { get; set; }
    }
}

