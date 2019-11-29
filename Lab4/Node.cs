using System;

namespace Lab4
{
    public class Node
    {
        public int Key;
        public Node Left;
        public Node Right;
        public int LeftCounter;
        public int RightCounter;

        public Node(int value)
        {
            this.Key = value;
        }

        public override string ToString()
        {
            return Key.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            return false;
            Node compare = (Node) obj;
            return compare.Key == this.Key;
        }

        public bool IsLeaf()
        {
            return this.Left == null && this.Right == null;
        }
    }

}