using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] edges = new int[,] { { 0, 1 }, { 1, 2 }, { 2, 3 }, { 3, 4 }, { 4, 5 }, { 5, 6 }, { 6, 3 }, { 6, 0 }, { 6, 1 }, { 1, 3 } };
            int[] weights = new int[10] { 1, 2, 1, 3, 2, 2, 1, 3, 3, 4 };
            IGraph graph = new GraphAdjacencyList(7);

            for (int i = 0; i < 10; i++)
            {
                graph.AddEdge(graph.GetVertex(edges[i, 0]), graph.GetVertex(edges[i, 1]), weights[i]);
            }

            // IGraph sceleton = GraphWorker.Prim(graph);
            // sceleton.Edges().ForEach(edge =>
            // {
            //     Console.Out.WriteLine(edge.ToString());
            // });


            GraphProps graphProps = GraphWorker.WaveAlgorithm(graph, graph.GetVertex(0));
            Console.Out.WriteLine(graphProps);
            graph.Vertices().ForEach(vertex =>
            {
                Console.Out.WriteLine(vertex.ToString());
            });

        }
    }
}
