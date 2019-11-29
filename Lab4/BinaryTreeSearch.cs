using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab4
{
    class BinaryTreeSearch
    {
        private Node root;
        //
        public Node GetRoot
        {
            get { return root; }
        }

        public BinaryTreeSearch() { }

        public BinaryTreeSearch(Node root)
        {
            this.root = root;
        }

        private Node RecursionInsert(Node tmp, Node newNode)
        {
            if (newNode.Key > tmp.Key)
            {
                tmp.RightCounter++;
                if (tmp.Right == null) return tmp.Right = newNode;
                else return RecursionInsert(tmp.Right, newNode);
            }
            else
            {
                tmp.LeftCounter++;
                if (tmp.Left == null) return tmp.Left = newNode;
                else return RecursionInsert(tmp.Left, newNode);
            }
        }

        public Node Insert(int value)
        {
            Node node = new Node(value);

            if (root == null) root = node;
            else RecursionInsert(root, node);
            return node;
        }

        public Node Find(int value)
        {
            return RecursionFind(root, value);
        }

        private Node RecursionFind(Node tmp, int value)
        {
            if (tmp == null) return null;
            if (tmp.Key == value) return tmp;
            if (value > tmp.Key) return RecursionFind(tmp.Right, value);
            else return RecursionFind(tmp.Left, value);

        }

        public void DisplayTree(string type, bool withDegree)
        {
            if (type == "inc") DisplayIncrease(root, withDegree);
            else DisplayDecrease(root, withDegree);
        }

        private void DisplayIncrease(Node tmp, bool withDegree)
        {
            if (tmp == null) return;
            DisplayIncrease(tmp.Left, withDegree);
            if (!withDegree) Console.Out.Write($"{tmp.Key} ");
            else Console.Out.Write($"{tmp.Key} ({tmp.LeftCounter}, {tmp.RightCounter}) ");
            DisplayIncrease(tmp.Right, withDegree);
        }

        private void DisplayDecrease(Node tmp, bool withDegree)
        {
            if (tmp == null) return;
            DisplayDecrease(tmp.Right, withDegree);
            if (!withDegree) Console.Out.Write($"{tmp.Key} ");
            else Console.Out.Write($"{tmp.Key} ({tmp.LeftCounter}, {tmp.RightCounter}) ");
            DisplayDecrease(tmp.Left, withDegree);
        }

        public Node FindMax(int k)
        {
            if (k > root.LeftCounter + root.RightCounter + 1) return null;
            return FindMaxRecursion(root, k);
        }

        private Node FindMaxRecursion(Node tmp, int k)
        {
            if (tmp.RightCounter == k - 1) return tmp;
            if (k > tmp.RightCounter) return FindMaxRecursion(tmp.Left, k - tmp.RightCounter - 1);
            else return FindMaxRecursion(tmp.Right, k);
        }

        public Node FindMin(int k)
        {
            if (k > root.LeftCounter + root.RightCounter + 1) return null;
            return FindMaxRecursion(root, k);
        }

        private Node FindMinRecursion(Node tmp, int k)
        {
            if (tmp.LeftCounter == k - 1) return tmp;
            if (k > tmp.LeftCounter) return FindMaxRecursion(tmp.Right, k - tmp.LeftCounter - 1);
            else return FindMaxRecursion(tmp.Left, k);
        }

        public Node LeftRotate(Node x)
        {
            Node y = x.Left;
            Node tmp = y.Right;
            y.Right = x;
            x.Left = tmp;

            int countTemp = y.RightCounter;
            y.RightCounter = y.RightCounter + x.RightCounter + 1;
            x.LeftCounter = countTemp;

            return y;
        }

        public Node RightRotate(Node x)
        {
            Node y = x.Right;
            Node tmp = y.Left;
            y.Left = x;
            x.Right = tmp;

            int countTemp = y.LeftCounter;
            y.LeftCounter = y.LeftCounter + x.LeftCounter + 1;
            x.RightCounter = countTemp;

            return y;
        }

        public void Root(Node node)
        {
            if (root.Equals(node))
                return;

            Stack<String> direction = new Stack<string>();
            Stack<Node> parents = new Stack<Node>();
            ParentStackRecursion(root, node, parents, direction);

            while (parents.Count > 0)
            {
                Node parent = parents.Pop();
                String dir = direction.Pop();

                Node nextParent;
                String nextDir;

                if (parents.Count != 0)
                {

                    nextParent = parents.Peek();
                    nextDir = direction.Peek();

                }
                else
                {
                    nextParent = root;
                    nextDir = "left";
                }

                Node newRoot;
                if (dir.Equals("left"))
                {
                    newRoot = LeftRotate(parent);
                }
                else
                {
                    newRoot = RightRotate(parent);
                }

                if (parents.Count != 0)
                {
                    if (nextDir.Equals("left"))
                    {
                        nextParent.Left = newRoot;
                    }
                    else
                    {
                        nextParent.Right = newRoot;
                    }
                }
                else
                {
                    this.root = newRoot;
                }
            }
        }
        private void ParentStackRecursion(Node temp, Node child, Stack<Node> parents, Stack<String> direction)
        {

            if (temp == null)
                return;
            parents.Push(temp);
            if (child.Equals(temp.Left))
            {
                direction.Push("left");
                return;
            }
            if (child.Equals(temp.Right))
            {
                direction.Push("right");
                return;
            }
            int value = child.Key;
            if (value > temp.Key)
            {
                direction.Push("right");
                ParentStackRecursion(temp.Right, child, parents, direction);
            }
            else
            {
                direction.Push("left");
                ParentStackRecursion(temp.Left, child, parents, direction);
            }
        }

        public void Balance()
        {
            this.root = BalanceRecursion(root);
        }

        private Node BalanceRecursion(Node root)
        {
            int n = root.LeftCounter + root.RightCounter + 1;
            if (n <= 2)
                return root;

            BinaryTreeSearch temp = new BinaryTreeSearch(root);
            Node mid = temp.FindMax(n / 2 + 1);
            temp.Root(mid);

            if (mid.Left != null)
                mid.Left = temp.BalanceRecursion(mid.Left);

            if (mid.Right != null)
                mid.Right = temp.BalanceRecursion(mid.Right);


            return mid;
        }
    }
}