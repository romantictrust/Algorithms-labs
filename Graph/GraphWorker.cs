using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphWorker
    {
        public static double CountWeight(IGraph graph)
        {
            List<Edge> edges = graph.Edges();
            double sum = 0;
            
            edges.ForEach(edge => sum += edge.Weight);
            return sum;
        }

        public static Stack<Vertex> Euler(IGraph graph)
        {
            int size = graph.Size;

            // IGraph temp = Object.Clone(graph)
            //Delete edges
            Stack<Vertex> s = new Stack<Vertex>();
            Stack<Vertex> c = new Stack<Vertex>(); //Queue

            int[,] edgeMatrix = new int[size, size];
            
            if (graph.Size == 0)
            {
                return c;
            }
            
            Vertex v = new Vertex(0);
            s.Push(v);

            while (true)
            {
                Vertex[] surrounding = graph.Surrounding(v).ToArray();

                bool flag = false;
                for (int i = 0; i < surrounding.Length; i++)
                {
                    Vertex temp = surrounding[i];
                    if (edgeMatrix[temp.Index, v.Index] == 0)
                    {
                        edgeMatrix[temp.Index, v.Index] = 1;
                        edgeMatrix[v.Index, temp.Index] = 1;
                        flag = true;
                        v = temp;
                        s.Push(temp);
                        break;
                    }
                }

                if (flag == false)
                {
                    c.Push(s.Pop());
                    try
                    {
                        v = s.Peek();
                    }
                    catch (System.InvalidOperationException)
                    {
                        return c;
                    }
                }
            }

        }

        public static IGraph Kraskal(IGraph graph)
        {
            int size = graph.Size;
            IGraph sceleton = new GraphAdjacencyList(size);

            List<Edge> edges = graph.Edges();
            edges.Sort((e1, e2) => (int)(e1.Weight - e2.Weight));
            int[] components = new int[size];
            for (int i = 0; i < size; i++)
            {
                components[i] = i;
            }
            int k = 0;
            while (k < size - 1)
            {
                Edge edge = edges.First();
                
                if (components[edge.FirstVertex.Index] != components[edge.SecondVertex.Index])
                {
                    sceleton.AddEdge(edge);
                    int first = edge.FirstVertex.Index;
                    int second = edge.SecondVertex.Index;
                    for (int i = 0; i < size; i++)
                    {
                        if (components[i] == second)
                        {
                            components[i] = first;
                        }
                    }

                    k++;
                }

                edges.Remove(edge);
            }

            return sceleton;
        }

        public static GraphProps WaveAlgorithm(IGraph graph, Vertex start)
        {    
            graph.Vertices().ForEach(vertex => { vertex.Colour = 0; });
            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(start);
            GraphProps graphProps = new GraphProps();
            start.Colour = 1;
            
            while (queue.Count > 0)
            {
                Vertex temp = queue.Dequeue();
                List<Vertex> surrounding = graph.Surrounding(temp);
                surrounding.ForEach(vertex =>
                {
                    if (vertex.Colour == 0)
                    {
                        vertex.Colour = temp.Colour + 1;
                        queue.Enqueue(vertex);
                        vertex.ComeFrom = temp;
                    } else if (vertex.Colour % 2 == temp.Colour % 2)
                    {
                        graphProps.IsBipartite = false;
                    }
                });
            }
            graphProps.IsConnected = true;

            foreach (var vertex in graph.Vertices())
            {
                if (vertex.Colour == 0)
                {
                    graphProps.IsConnected = false;
                    break;
                }
            }
            return graphProps;
        }

        public static IGraph Prim(IGraph graph)
        {
            IGraph sceleton = new GraphAdjacencyList(graph.Size);

            Vertex start = graph.GetVertex(0);
            
            List<Vertex> passed = new List<Vertex>();
            passed.Add(start);
            start.Colour = 1;
            
            while (passed.Count != graph.Size)
            {    
                double minWeight = Double.PositiveInfinity;
                Edge minEdge = null;
                Edge temp;
                
                passed.ForEach(vertex =>
                {
                    graph.Surrounding(vertex).ForEach(surround =>
                    {
                        if (surround.Colour == 0)
                        {
                            temp = graph.GetEdge(vertex, surround);
                            if (temp.Weight < minWeight)
                            {
                                minWeight = temp.Weight;
                                minEdge = temp;
                            }   
                        }         
                    });
                });
                Vertex next = graph.GetVertex(minEdge.SecondVertex.Index);
                sceleton.AddEdge(minEdge);
                next.Colour = 1;
                passed.Add(next);
            }

            return sceleton;
        }
    }
}