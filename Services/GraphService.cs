using Graph_API_Visualizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace Graph_API_Visualizer.Services
{
    public static class GraphService
    {
        static List<Graph> Graphs { get; }

        static int nextId = 0;
        static int nextNodeId = 0;
        static int nextEdgeId=0;

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
            node.Id = nextNodeId++;
            var lista = Get(id).Nodes;
            lista.Add(node);
        }   
        public static List<Node> GetNodes(int id)
        {
            var nodos = Get(id).Nodes;
            return nodos;
        }

        public static void UpdateNode(int id, object entity)
        {
            var lista = GetNodes(id);
            var node = new Node();
            foreach(Node nodo in lista)
                    {
                        if (nodo.Id == id)
                        {
                            node = nodo;
                            break;
                        }
                    }

                    node.Entity=entity;
        }

        public static void DeleteNode(int idg, int idn)  
        {
            var lista = GetNodes(idg);
            foreach (Node nodo in lista)
            {
                if (nodo.Id == idn)
                {
                    lista.Remove(nodo);
                    break;
                }
            }
        }

        public static void DeleteAllNode(int idg)
        {
            List<Node> graph= Get(idg).Nodes;
            graph.Clear();
        }

        public static List<Edges> GetEdges(int id)
        {
            return Get(id).Edges;
        }
        public static void DeleteAllEdges(int idg)
        {
            List<Edges> graph= Get(idg).Edges;
            graph.Clear();
        }
        public static void AddEdge(int id, Edges edge) //aca
        {
            edge.Id = nextEdgeId++;
            var lista = Get(id).Edges;
            lista.Add(edge);
        }   

        public static void UpdateEdges(int id, int idStart, int idEnd, int weight)
        {
            var NLista = GetNodes(id);
            var lista = GetEdges(id);
            var edge = new Edges();
            foreach(Edges arista in lista)
                    {
                        if (arista.Id == id)
                        {
                            edge = arista;
                            break;
                        }
                    }/*
                    foreach(Node node in NLista)
                    {
                        if(idStart == node.Id)
                        {
                            edge.Start = node;
                            break;
                        }
                    }
                    foreach(Node node in NLista)
                    {
                        if(idEnd == node.Id)
                        {
                            edge.End = node;
                            break;
                        }
                    }*/
                    edge.Weight = weight;
        }
   }
}
    

