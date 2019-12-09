namespace Graph
{
    public class GraphProps
    {
        private bool _isBipartite;
        private bool _isConnected;
        
        public bool IsBipartite
        {
            get => _isBipartite;
            set => _isBipartite = value;
        }
        
        public bool IsConnected
        {
            get => _isConnected;
            set => _isConnected = value;
        }

        public override string ToString()
        {
            return "GraphProps[ isBipartite:" + _isBipartite + "; isConnected:" + _isConnected +"]";
        }
    }
}