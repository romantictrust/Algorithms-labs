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
            Sorts srt = new Sorts();
            ArrayCreator arr = new ArrayCreator(arrLen, fromTo);
            int[] filledArr = arr.Arr;
            var watch = System.Diagnostics.Stopwatch.StartNew();
            srt.QuickSort(filledArr, start, end, true);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("QS Random: {0}ms", elapsedMs);

            
            ArrayCreator arr1 = new ArrayCreator(arrLen, fromTo);
            int[] filledArr1 = arr1.Arr;
            var watch1 = System.Diagnostics.Stopwatch.StartNew();
            srt.QuickSort(filledArr1, start, end, false);
            watch.Stop();
            var elapsedMs1 = watch.ElapsedMilliseconds;
            Console.WriteLine("QS Regular: {0}ms", elapsedMs1);

            // foreach (var entry in filledArr)
            // {
            //     Console.Write("{0} ", entry);
            // }
        }
    }
}
