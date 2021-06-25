using Graph_API_Visualizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Graph_API_Visualizer.Services
{
    public static class GraphService
    {
        static List<Graph> Graphs { get; }

        static int nextId = 0;

        static GraphService()
        {
            Graphs = new List<Graph>
            {

            };
        }

        public static List<Graph> GetAll() => Graphs;

        public static Graph Get(int id) => Graphs.FirstOrDefault(p => p.Id == id);

        public static void Add(Graph graph)
        {
            graph.Id = nextId++;
            Graphs.Add(graph);
        }

        public static void Delete(int id)
        {
            var graph = Get(id);
            if(graph is null)
                return;

            Graphs.Remove(graph);
        }

        public static void DeleteAll()
        {
            Graphs.Clear();
        }

        public static void AddNode(int id, Node node)
        {
            if(Get(id).Nodes == null)
            {
                Get(id).Nodes.Add(node);
                Get(id).Nodes.Find(0)
            }
        }
    }
}
