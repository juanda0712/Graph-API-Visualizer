namespace Graph_API_Visualizer.Models
{
    /// <summary>
    /// The  Node class.
    /// Contains all methods to define the Node
    /// </summary>
    /// <remarks>
    /// This class can set and get de attributes to the Node object
    /// </remarks>
    public class Node
    {
        public int Id { get; set; }
        public int InDegree { get; set; }
        public int OutDegree { get; set; }
        public object Entity{ get; set;}
    }
}