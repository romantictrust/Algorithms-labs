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
                int pivot = FindNewPiv(arr, left, right);
                QuickSort(arr, left, pivot - 1, isRand);
                QuickSort(arr, pivot + 1, right, isRand);
            }
        }

        private int FindNewPiv(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int j = left;
            for (int i = left; i < right; i++)
            {
                if (arr[i] < pivot)
                {
                    Swap(arr, i, j++);
                }
            }

            Swap(arr, j, right);
            return j;
        }

        public void InsertionSort(int[] arr, int left, int right)
        {
            //  1
            int j;
            //       1        1       1        2    ** n-1 iterational loop stands for 2 + 3(n-1) **
            for (int i = left + 1; i <= right; i++)
            {
                // 1  1    ** 2(n-1) **
                j = i - 1;
                // while loop worst case: in for loop (i) iteration will pass i times
                // iterations amount 1 + 2 + ... + n-1 = ** n(n-1)/2 **
                //        1      1      1  1     1 1    ** 6 **
                while (j >= left && arr[j] > arr[j + 1])
                {
                    // 1           1
                    Swap(arr, j, j + 1); 
                    // 2 
                    j--;
                    //  ** 4 **
                }
                // while loop worst case: 10*n(n-1)/2 = 5*n(n-1)
            }
            // Summery: 1 + 2 + 3(n-1) + 2(n-1) + 5*n(n-1) = 3 + 5(n-1) + 5n(n-1) = 5n^2 - 2;
            // Complexity: O(n(n-1))
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
                    int q = FindNewPiv(arr, left, right);
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