using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class GraphAdjacencyList : IGraph
    {
        private Dictionary<Vertex, double>[] _adjacencyList; 
        private int _size;

        private Vertex[] _vertices;
        
        public GraphAdjacencyList(int size)
        {
            _size = size;
            _adjacencyList = new Dictionary<Vertex, double>[size];
            _vertices = new Vertex[size];
            for (int i = 0; i < size; i++)
            {
                _adjacencyList[i] = new Dictionary<Vertex, double>();
                _vertices[i] = new Vertex(i);
            }
            
        }

        public int Size => _size;

        public void AddEdge(Vertex firstVertex, Vertex secondVertex, double weight = 1)
        {
            _adjacencyList[firstVertex.Index].Add(_vertices[secondVertex.Index], weight);
            _adjacencyList[secondVertex.Index].Add(_vertices[firstVertex.Index], weight); // TODO remove for OrGraph
        }

        public void AddEdge(Edge edge)
        {
            AddEdge(edge.FirstVertex, edge.SecondVertex, edge.Weight);
        }

        public void RemoveEdge(Vertex firstVertex, Vertex secondVertex)
        {
            _adjacencyList[firstVertex.Index].Remove(secondVertex);
            _adjacencyList[secondVertex.Index].Remove(firstVertex); // TODO remove for OrGraph
        }

        public List<Vertex> Surrounding(Vertex vertex)
        {
            List<Vertex> vertices = new List<Vertex>();
            foreach (var keyValuePair in _adjacencyList[vertex.Index])
            {
                vertices.Add(keyValuePair.Key);
            }

            return vertices;
        }

        public int Degree(Vertex vertex)
        {
            return _adjacencyList[vertex.Index].Count;
        }

        public bool IsAdjacent(Vertex firstVertex, Vertex secondVertex)
        {
            return _adjacencyList[firstVertex.Index].ContainsKey(secondVertex);
        }

        public List<Edge> Edges()
        {
            List<Edge> edges = new List<Edge>();

            for (var i = 0; i < _adjacencyList.Length; i++)
            {
                Dictionary<Vertex, double> dictionary = _adjacencyList[i];

                foreach (var keyValuePair in dictionary)
                {
                    Edge edge = new Edge(new Vertex(i), keyValuePair.Key, keyValuePair.Value);
                    if (!edges.Contains(edge))
                    {
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
                double weight =_adjacencyList[start.Index][end];
                return new Edge(start, end, weight);
            }
            else
            {
                return null;
            }
        }
    }
    
    
}