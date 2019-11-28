using System;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int from = 0;
            int to = (int)Math.Pow(10, 7);
            int[] fromTo = { from, to };
            int size = (int)Math.Pow(10, 7);

            ArrayCreator objArr = new ArrayCreator(size, fromTo);
            int[] arr = objArr.getArray;
        }
    }
}
