using System;

namespace Lab3
{
    public class Searches
    {
        public int IncrementalSearch(int[] arr, int element, ref int? counter)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                counter++;
                if (arr[i] == element)
                {
                    return i;
                }
            }
            return -1;
        }

        public int BinarySearch(int[] arr, int element, ref int? counter)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l <= r)
            {
                int middle = (l + r) / 2;
                counter++;
                if (arr[middle] == element)
                {
                    return middle;
                }
                else if (element < arr[middle])
                {
                    r = middle - 1;
                }
                else
                {
                    l = middle + 1;
                }
            }

            return -1;
        }

        public int InterpolationSearch(int[] arr, int element, ref int? counter)
        {
            int l = 0;
            int r = arr.Length - 1;
            double k = 0;
            int middle;
            while (l < r)
            {
                if (k > 1)
                {
                    break;
                }

                counter++;
                k = Math.Abs((element - arr[l]) * 1.0 / (arr[r] - arr[l]));
                middle = (int)Math.Truncate((l + k * (r - l)));
                if (arr[middle] == element)
                {
                    return middle;
                }
                else if (element < arr[middle])
                {
                    r = middle - 1;
                }
                else
                {
                    l = middle + 1;
                }
            }

            return -1;
        }

    }

}