using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.DataStructures.Graph
{
    class Graph
    {
        List<Vertex> Vertexes = new List<Vertex>();

        List<Edge> Edges = new List<Edge>();

        public int VertexCount => Vertexes.Count;
        public int EdgeCount => Edges.Count;

        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddEdge(Vertex from, Vertex to)
        {
            var edge = new Edge(from, to);
            Edges.Add(edge);
        }

        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach (var edge in Edges)
            {
                // Number -1 ,чтобы не было смещения при выводе (so that there is no offset in the output )
                var row = edge.From.Number -1 ;
                var column = edge.To.Number -1 ;

                matrix[row, column] = edge.Weight;
            }

            return matrix;
        }

        public List<Vertex> GetVetexLists(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach (var edge in Edges)
            {
                if (edge.From == vertex)
                {
                    result.Add(edge.To);
                }
            }

            return result;
        }

        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>
            {
                start
            };

            for (int i = 0; i < list.Count; i++)
            {
                var vertex = list[i];
                foreach (var v in GetVetexLists(vertex))
                {
                    if (!list.Contains(v))
                    {
                        list.Add(v);
                    }
                }
            }

            return list.Contains(finish);
        }
        //GetVertex private needed for easy viewing (Graph)
        public static void GetVertex(Graph graph, Vertex vertex)
        {
            Console.Write(vertex.Number + ": ");
            foreach (var v in graph.GetVetexLists(vertex))
            {
                Console.Write(v.Number + ", ");
            }
            Console.WriteLine();
        }

        // GetMatrix private needed for easy viewing (Graph)
        public static void GetMatrix(Graph graph)
        {
            int[,] matrix = graph.GetMatrix();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write(" | " + matrix[i, j] + " | ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("____________________________________________________________");
            Console.WriteLine(" ");
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write($" | {i + 1} | ");
            }
        }

    }
}
