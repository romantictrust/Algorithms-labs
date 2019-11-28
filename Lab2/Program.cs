using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            int arrLen = 10000000;
            int[] fromTo = { -5000000, 5000000 };
            int start = 0;
            int end = arrLen - 1;
            int leftUnsorted = 10;
            Sorts srt = new Sorts();

            ArrayCreator arr1 = new ArrayCreator(arrLen, fromTo);
            int[] filledArr1 = arr1.Arr;
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            srt.MergeSort(filledArr1, start, end);
            watch1.Stop();
            var elapsedMs1 = watch1.ElapsedMilliseconds;
            Console.WriteLine("MergeSort: {0}ms", elapsedMs1);

            ArrayCreator arr = new ArrayCreator(arrLen, fromTo);
            int[] filledArr = arr.Arr;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            srt.CombinedSort(filledArr, start, end, leftUnsorted);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("CombinedSort: {0}ms", elapsedMs);

            // foreach (var entry in filledArr)
            // {
            //     Console.Write("{0} ", entry);
            // }
        }
    }
}
