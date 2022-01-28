using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.AlgSortingWithoutGenerics
{
    class BubbleSort
    {
        public static void BubbleSorting(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length - 1; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        int temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }
        public static void BubbleSorting(string[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
            {
                for (int j = 0; j < Array.Length - 1; j++)
                {
                    if (String.Compare(Array[j] ,Array[j + 1]) > 0)
                    {
                        var temp = Array[j];
                        Array[j] = Array[j + 1];
                        Array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
