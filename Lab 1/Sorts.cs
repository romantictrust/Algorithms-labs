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

        public void InsertionSort(int[] arr, int left, int right)
        {
            int j;
            for (int i = left + 1; i <= right; i++)
            {
                j = i - 1;
                while (j >= left && arr[j] > arr[j + 1])
                {
                    Swap(arr, j, j + 1);
                    j--;
                }
            }
        }

        public void CombinedSort(int[] arr, int left, int right, int leftUnsorted)
        {
            if (left < right)
            {
                if (right - left + 1 <= leftUnsorted)
                {
                    InsertionSort(arr, left, right);
                }
                else
                {
                    int q = FindPivot(arr, left, right);
                    CombinedSort(arr, left, q - 1, leftUnsorted);
                    CombinedSort(arr, q + 1, right, leftUnsorted);
                }
            }
        }

        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

    }
}