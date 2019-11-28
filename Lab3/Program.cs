using System;
using System.IO;

namespace Lab3
{
    class Program
    {
        static private String path = @"D:\Tsyrkunov\Algorithms-labs\Lab3\logs.txt";
        static private String tableTitles = String.Format("№ |   Incremental   |  Binary  |  Interpolation\n");
        static void Main(string[] args)
        {
            int from = 0;
            int to = (int)Math.Pow(10, 7);
            int[] fromTo = { from, to };
            int size = (int)Math.Pow(10, 7);
            File.WriteAllText(path, tableTitles);
            int iterations = 25;
            Searches search = new Searches();

            for (int i = 0; i < iterations; i++)
            {
                ArrayCreator objArr = new ArrayCreator(size, fromTo);
                int[] arr = objArr.getArray;
                int targetElement = (new Random()).Next(from, to);
                Array.Sort(arr);

                File.AppendAllText(path, $"\n{i}");

                var watch = System.Diagnostics.Stopwatch.StartNew();
                int? counter = 0;
                int index = search.IncrementalSearch(arr, targetElement, ref counter);
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                String result = $" | ms:{elapsedMs} c:{counter}";
                File.AppendAllText(path, result);

                watch = System.Diagnostics.Stopwatch.StartNew();
                counter = 0;
                index = search.BinarySearch(arr, targetElement, ref counter);
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
                result = $" | ms:{elapsedMs} c:{counter}";
                File.AppendAllText(path, result);

                watch = System.Diagnostics.Stopwatch.StartNew();
                counter = 0;
                index = search.InterpolationSearch(arr, targetElement, ref counter);
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
                result = $" | ms:{elapsedMs} c:{counter}";
                File.AppendAllText(path, result);
            }

        }
    }
}
