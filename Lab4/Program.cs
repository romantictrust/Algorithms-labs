using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree BST = new BinarySearchTree();
            int from = 0;
            int to = (int)Math.Pow(10, 7);
            int[] fromTo = { from, to };
            int size = (int)Math.Pow(10, 7);

            ArrayCreator objArr = new ArrayCreator(size, fromTo);
            int[] arr = objArr.getArray;

            foreach (int i in arr)
            {
                BST.Insert(i);
            }

            Console.Out.WriteLine("---- Tree created ----");
            var watch = System.Diagnostics.Stopwatch.StartNew();

            DateTime start = DateTime.Now;

            BST.Balance();

            DateTime finish = DateTime.Now;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.Out.WriteLine($"Tree balances, time: {(finish - start).TotalMilliseconds}");
            Console.Out.WriteLine($"Tree balances, time: {elapsedMs}");
        }
    }
}
