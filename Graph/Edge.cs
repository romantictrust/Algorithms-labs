namespace Graph
{
    public class Edge
    {
        private Vertex _firstVertex;
        private Vertex _secondVertex;
        private double _weight;
        private int color;
        
        public Vertex FirstVertex
        {
            get => _firstVertex;
            set => _firstVertex = value;
        }

        public Vertex SecondVertex
        {
            get => _secondVertex;
            set => _secondVertex = value;
        }

        public double Weight
        {
            get => _weight;
            set => _weight = value;
        }

        public int Color
        {
            get => color;
            set => color = value;
        }

        public Edge(Vertex firstVertex, Vertex secondVertex, double weight = 1)
        {
            _firstVertex = firstVertex;
            _secondVertex = secondVertex;
            _weight = weight;
        }

        public override bool Equals(object obj)
        {
            Edge edge = (Edge) obj;
            return (this._firstVertex.Equals(edge._firstVertex) && this._secondVertex.Equals(edge._secondVertex))
                   || (this._firstVertex.Equals(edge._secondVertex) && this._secondVertex.Equals(edge._firstVertex));
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"({_firstVertex.Index},{_secondVertex.Index})";
        }
    }
}