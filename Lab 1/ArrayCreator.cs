using System;

namespace Global
{
    public class ArrayCreator
    {
        private int[] arr;
        public ArrayCreator(int len, int[] fromTo)
        {
            arr = new int[len];
            arr = fillArr(arr, fromTo);
        }

        public int[] fillArr(int[] arr, int[] fromTo)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = rnd.Next(fromTo[0], fromTo[1]);
            }
            return arr;
        }

        public int[] Arr
        {
            get { return arr; }
        }
    }
}