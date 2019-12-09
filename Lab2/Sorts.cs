using System;

namespace Lab2
{
    public class Sorts
    {
        public void CombinedSort(int[] arr, int left, int right, int leftUnsorted)
        {

            if (right - left + 1 <= leftUnsorted)
            {
                InsertionSort(arr, left, right);
            }
            else
            {
                int mid = (left + right) / 2;
                CombinedSort(arr, left, mid, leftUnsorted);
                CombinedSort(arr, mid + 1, right, leftUnsorted);
                Merge(arr, left, mid, right);
            }

        }

        public void MergeSort(int[] arr, int left, int right)
        {
            if (right - left >= 1)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private void Merge(int[] arr, int p, int m, int r)
        {
            int left = p;
            int right = m + 1;

            int[] result = new int[r - p + 1];
            int k = 0;
            while (left <= m && right <= r)
            {
                if (arr[left] > arr[right])
                {
                    result[k] = arr[right];
                    right++;
                }
                else
                {
                    result[k] = arr[left];
                    left++;
                }

                k++;
            }

            while (left <= m)
            {
                result[k] = arr[left];
                k++;
                left++;
            }

            while (right <= r)
            {
                result[k] = arr[right];
                k++;
                right++;
            }

            for (int i = p; i <= r; i++)
            {
                arr[i] = result[i - p];
            }
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

        private void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

    }
}