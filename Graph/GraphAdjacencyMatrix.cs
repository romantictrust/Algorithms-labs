using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphAdjacencyMatrix : IGraph
    {
        private double[,] _adjacencyMatrix;
        private int _size;
        private Vertex[] _vertices;
        
        public GraphAdjacencyMatrix(int size)
        {
            _size = size;
            _adjacencyMatrix = new double[size, size];
            _vertices = new Vertex[size];
            for (int i = 0; i < size; i++)
            {
                _vertices[i] = new Vertex(i);
                for (int j = 0; j < size; j++)
                {
                    _adjacencyMatrix[i, j] = double.PositiveInfinity;
                }
            }
        }

        public int Size => _size;

        public void AddEdge(Vertex firstVertex, Vertex secondVertex, double weight = 1)
        {
            _adjacencyMatrix[firstVertex.Index, secondVertex.Index] = weight;
            _adjacencyMatrix[secondVertex.Index, firstVertex.Index] = weight; // TODO remove for OrGraph
        }

        public void AddEdge(Edge edge)
        {
            AddEdge(edge.FirstVertex, edge.SecondVertex, edge.Weight);
        }
        
        public void RemoveEdge(Vertex first, Vertex second)
        {
            _adjacencyMatrix[first.Index, second.Index] = double.PositiveInfinity;
            _adjacencyMatrix[second.Index, first.Index] = double.PositiveInfinity; // TODO remove for OrGraph
        }

        public List<Vertex> Surrounding(Vertex vertex)
        {
            List<Vertex> vertices = new List<Vertex>();
            int index = vertex.Index;
            for (int i = 0; i < _size; i++)
            {
                if (!double.IsPositiveInfinity(_adjacencyMatrix[index, i]))
                {
                    vertices.Add(_vertices[i]);
                }
            }

            return vertices;
        }

        public int Degree(Vertex vertex)
        {
            int degree = 0;
            for (int i = 0; i < _size; i++)
            {
                if (!double.IsPositiveInfinity(_adjacencyMatrix[vertex.Index, i]))
                {
                    degree++;
                }
            }

            return degree;
        }
        
        public bool IsAdjacent(Vertex firstVertex, Vertex secondVertex)
        {
            return (!double.IsPositiveInfinity(_adjacencyMatrix[firstVertex.Index, secondVertex.Index]));
        }

        public List<Edge> Edges()
        {
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < _size; i++)
            {
                for (int j = i; j < _size; j++) // TODO change indexes for j for OrGraph
                {
                    if (!double.IsPositiveInfinity(_adjacencyMatrix[i, j]))
                    {
                        Edge edge = new Edge(new Vertex(i), new Vertex(j), _adjacencyMatrix[i,j]);
                        edges.Add(edge);
                    }
                }
            }

            return edges;
        }

        public Vertex GetVertex(int index)
        {
            return _vertices[index];
        }

        public List<Vertex> Vertices()
        {
            return _vertices.ToList();
        }

        public Edge GetEdge(Vertex start, Vertex end)
        {
            if (IsAdjacent(start, end))
            {
                double weight = _adjacencyMatrix[start.Index, end.Index];
                return new Edge(start, end, weight);
            }
            else
            {
                return null;
            }
            //return new Edge(start, end, _);
        }
    }
}