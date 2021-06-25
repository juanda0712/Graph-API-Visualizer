using System.Collections.Generic;

namespace Graph_API_Visualizer.Models
{
    public class Edges
    {
        public int Id { get; set; }
        public Node Start { get; set; }
        public Node End { get; set; }
        public int Weight { get; set; }
    }
}
