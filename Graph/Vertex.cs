using System;

namespace Graph
{
    public class Vertex
    {
        private int _index;
        private int _colour;
        private Vertex _comeFrom;
        
        public Vertex(int index, int colour = 0)
        {
            _index = index;
            _colour = colour;
        }
        
        public int Colour
        {
            get => _colour;
            set => _colour = value;
        }

        public int Index
        {
            get => _index;
            set => _index = value;
        }

        public override bool Equals(object obj)
        {
            return this._index == ((Vertex) obj)._index;
        }

        public override string ToString()
        {
            String comeFromString = _comeFrom == null ? "no" : _comeFrom.Index.ToString();  
            return $"Vertex[id:{_index}, colour: {_colour}, comeFrom: {comeFromString}]";
        }
        
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        
        public Vertex ComeFrom
        {
            get => _comeFrom;
            set => _comeFrom = value;
        }
    }
}