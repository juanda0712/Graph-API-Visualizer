using System.Collections.Generic;

namespace Graph_API_Visualizer.Models
{
    /// <summary>
    /// The  Edges class.
    /// Contains all methods to define the edges
    /// </summary>
    /// <remarks>
    /// This class can set and get de attributes to the edge object
    /// </remarks>
    public class Edges
    {   
        public int Id { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public int Weight { get; set; }
    }
}
