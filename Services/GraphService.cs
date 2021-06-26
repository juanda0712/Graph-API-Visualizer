using Graph_API_Visualizer.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace Graph_API_Visualizer.Services
{   
    /// <summary>
    /// The  GraphService class.
    /// Contains all methods to define the GraphService
    /// </summary>
    /// <remarks>
    /// This class can GetAll, Get, Add, Delete, DeleteAll, AddNode, GetNodes, GetNodeAt
    /// UpdateNode, DeleteNode, DeleteAllNode, GetEdges, DeleteAllEdges, AddEdge, VerifyNode
    /// UpdateEdges, OrderList.
    /// </remarks>
    public static class GraphService
    {
        static List<Graph> Graphs { get; }

        static int nextId = 0;
        static int nextNodeId = 0;
        static int nextEdgeId = 0;
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

        private static Node GetNodeAt(int idGraph, int idNode)
        {
            var lista = GetNodes(idGraph);
            var nodeAux = new Node();
            foreach(Node node in lista)
            {
                if(node.Id == idNode)
                {
                    nodeAux = node;
                    break;
                }
            }
            return nodeAux;
        }

        public static void UpdateNode(int id,int id2, object entity)
        {
            var lista = GetNodes(id);
            var node = new Node();
            foreach(Node nodo in lista)
                    {
                        if (nodo.Id == id2)
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
            if(VerifyNode(id,edge.Start) && VerifyNode(id, edge.End) && edge.Start != edge.End)
            {
                edge.Id = nextEdgeId++;
                var startNode = GetNodeAt(id, edge.Start);
                startNode.OutDegree++;
                var endNode = GetNodeAt(id, edge.End);
                endNode.InDegree++;
                var lista = Get(id).Edges;
                lista.Add(edge);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }  
        }

        private static bool VerifyNode(int idGraph, int idNode)
        {
            var lista = GetNodes(idGraph);
            bool exist = false;

            for(int i =0; i < lista.Count(); i++)
            {
                if(lista[i].Id == idNode)
                {
                    exist = true;
                    break;
                }
            }

            return exist;
        }   

        public static void UpdateEdges(int id,int id2, Edges edge)
        {
            var lista = GetEdges(id);
            var edgeAux = new Edges();
            foreach(Edges arista in lista)
            {
                if(arista.Id == id2)
                {
                    edgeAux = arista;
                    break;
                }
            }
            edgeAux.Weight = edge.Weight;
            edgeAux.Start = edge.Start;
            edgeAux.End = edge.End;
        }

        public static void DeleteEdge(int idg, int idn)  
        {
            var lista = GetEdges(idg);
            foreach (Edges edge in lista)
            {
                if (edge.Id == idn)
                {
                    lista.Remove(edge);
                    break;
                }
            }
        }

        public static List<Node> OrderList(bool order, List<Node> lista)
        {
            if(order)
            {
                int i=0;
                int j=0;
                for (int k = 0; k < lista.Count() ; k++,i=1,j=0) {
                    while (i < lista.Count()) {
                        if (lista[i].OutDegree < lista[j].OutDegree) {
                            var num1 = lista[i];
                            var num2 = lista[j];
                            lista[i] = num2;
                            lista[j] = num1;
                        }
                        i++;
                        j++;
                    }
                }
            }
            else
            {
                int i=0;
                int j=0;
                for (int k = 0; k < lista.Count() ; k++,i=1,j=0) {
                    while (i < lista.Count()) {
                        if (lista[i].InDegree < lista[j].InDegree) {
                            var num1 = lista[i];
                            var num2 = lista[j];
                            lista[i] = num2;
                            lista[j] = num1;
                        }
                        i++;
                        j++;
                    }
                }
            }
            return lista;
        }
   }
}
    

