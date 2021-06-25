namespace Graph_API_Visualizer.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int InDegree { get; set; }
        public int OutDegree { get; set; }
        public object entity{ get; set;}
    }
}