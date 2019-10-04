using System;

namespace Global
{
    class Program
    {
        static void Main()
        {
            int arrLen = 1000;
            int[] fromTo = { -1, 2 };
            ArrayCreator arr = new ArrayCreator(arrLen, fromTo);
            foreach (var entry in arr.Arr)
            {
                Console.Write("{0} ",entry);
            }
        }
    }
}
