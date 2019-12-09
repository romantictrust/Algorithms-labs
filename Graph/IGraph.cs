using System.Collections.Generic;

namespace Graph
{
    public interface IGraph
    {
        void AddEdge(Vertex firstVertex, Vertex secondVertex, double weight = 1);
        void AddEdge(Edge edge);
        void RemoveEdge(Vertex firstVertex, Vertex secondVertex);
        List<Vertex> Surrounding(Vertex vertex);// Neighbouring
        bool IsAdjacent(Vertex firstVertex, Vertex secondVertex);
        int Degree(Vertex vertex);
        List<Edge> Edges();
        int Size { get; }
        Vertex GetVertex(int index);
        Edge GetEdge(Vertex start, Vertex end);
        List<Vertex> Vertices();
    }
}