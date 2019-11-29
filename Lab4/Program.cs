using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTreeSearch BTS = new BinaryTreeSearch();
            int from = 0;
            int to = (int)Math.Pow(10, 7);
            int[] fromTo = { from, to };
            int size = (int)Math.Pow(10, 7);

            ArrayCreator objArr = new ArrayCreator(size, fromTo);
            int[] arr = objArr.getArray;

            foreach (int i in arr)
            {
                BTS.Insert(i);
            }

            Console.Out.WriteLine("---- Tree created ----");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            BTS.Balance();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.Out.WriteLine($"Tree balances, time: {elapsedMs}");
        }
    }
}
