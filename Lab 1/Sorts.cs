using System;

namespace Global
{
    public class Sorts
    {
        private Random random;

        public Sorts()
        {
            this.random = new Random();
        }

        public void QuickSort(int[] arr, int left, int right, bool isRand)
        {
            if (left < right)
            {
                if (isRand) Swap(arr, random.Next(left, right), right);
                int pivot = FindPivot(arr, left, right);
                QuickSort(arr, left, pivot - 1, isRand);
                QuickSort(arr, pivot + 1, right, isRand);
            }
        }

        private int FindPivot(int[] arr, int left, int right)
        {
            int x = arr[right];
            int pivot = left;
            for (int i = left; i < right; i++)
            {
                if (arr[i] < x)
                {
                    Swap(arr, i, pivot++);
                }
            }

            Swap(arr, pivot, right);
            return pivot;
        }

        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

    }
}