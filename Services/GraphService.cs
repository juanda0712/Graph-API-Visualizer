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

        public static Node AddNode(int id, Node node)
        {
            int nodeId=0;
            List<Node> lista=Get(id).Nodes;
            if(Get(id).Nodes == null)
            {
                lista.Add(node);
                lista.ElementAt<Node>(0).Id=nodeId;
                return lista.ElementAt<Node>(0);
            }
            else{
                int i=0;
                foreach (Node nodo in lista) {
                    nodeId=nodo.Id+1;
                    i++;
                }
                i++;
                lista.Add(node);
                lista.ElementAt<Node>(i).Id=nodeId;
                return lista.ElementAt<Node>(i);
                }
            }   
            public static List<Node> GetNodes(int id){
                List<Node> nodos=Get(id).Nodes;
                return nodos;
            }

            public static void DeleteNode(int idg, int idn){
                List<Node>graph=GetNodes(idg);
                foreach (Node node in graph){
                    if (idn==node.Id){
                        graph.Remove(node);
                    }
                }
            }

            public static void DeleteAllNode(int idg){
                List<Node> graph= Get(idg).Nodes;
                graph.Clear();
            }
        }
    }

