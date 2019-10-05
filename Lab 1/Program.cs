using System;

namespace Global
{
    class Program
    {
        static void Main()
        {
            int arrLen = 10000000;
            int[] fromTo = { -5000000, 5000000 };
            int start = 0;
            int end = arrLen - 1;
            ArrayCreator arr = new ArrayCreator(arrLen, fromTo);
            int[] filledArr = arr.Arr;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Sorts.QuickSort(filledArr, start, end);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("{0}ms", elapsedMs);
            // foreach (var entry in filledArr)
            // {
            //     Console.Write("{0} ", entry);
            // }
        }
    }
}
