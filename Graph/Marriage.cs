using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    public class Marriage
    {
        public static KeyValuePair<int,int>[] Generate(int[,] a, int[,] b)
        {
            int aSize = a.GetLength(0);
            int bSize = b.GetLength(0);
            
            while (true)
            {

                bool flag = true;
                for (int j = 0; j < bSize; j++)
                {
                    List<int> connected = getConnected(a, j+1);
                    if (connected.Count > 1)
                    {
                        flag = false;
                        int i = 0;
                        while (!connected.Contains(b[j, i]))
                        {
                            i++;
                        }
                        connected.Remove(b[j,i]);
                        
                        connected.ForEach(index =>
                        {
                            int k = 0;
                            while (a[index-1, k] == 0)
                            {
                                k++;
                            }

                            a[index-1 , k] = 0;    
                        });
                    }
                }

                if (flag) break;
            }

            KeyValuePair<int, int>[] result = new KeyValuePair<int, int>[aSize];
            for (int i = 0; i < aSize; i++)
            {
                int j = 0;
                while (a[i, j] == 0)
                {
                    j++;
                }
                result[i] = new KeyValuePair<int, int>(i+1, a[i,j]);
               // Console.Out.WriteLine($"{i+1} - {a[i,j]}");
            }

            return result;
        }

        private static List<int> getConnected(int[,] arr, int index)
        {
            List<int> list = new List<int>();
            int size = arr.GetLength(0);
            
            for (int i = 0; i < size; i++)
            {
                int k = 0;
                while (arr[i, k] == 0)
                {
                    k++;
                }

                if (arr[i, k] == index)
                {
                    list.Add(i+1);
                }
            }

            return list;
        }

        private static void display(int[,] arr)
        {
            int size = arr.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Out.Write(arr[i,j] + " ");
                }
                Console.Out.WriteLine();
            }
            Console.Out.WriteLine();
        }
    }
}