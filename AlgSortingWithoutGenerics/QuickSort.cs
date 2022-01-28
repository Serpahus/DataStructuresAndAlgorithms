using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.AlgSortingWithoutGenerics
{
    class QuickSort
    {
        public static int Partition(int[] Array, int start, int end)
        {
            int temp;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (Array[i] < Array[end]) //array[end] is pivot
                {
                    temp = Array[marker]; // swap
                    Array[marker] = Array[i];
                    Array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = Array[marker];
            Array[marker] = Array[end];
            Array[end] = temp;
            return marker;
        }

        public static void QuickSorting(int[] Array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(Array, start, end);
            QuickSorting(Array, start, pivot - 1);
            QuickSorting(Array, pivot + 1, end);
        }

        public static int Partition(string[] Array, int start, int end)
        {
            var temp=string.Empty;//swap helper
            int marker = start;//divides left and right subarrays
            for (int i = start; i <= end; i++)
            {
                if (String.Compare(Array[i] , Array[end])<0) //array[end] is pivot
                {
                    temp = Array[marker]; // swap
                    Array[marker] = Array[i];
                    Array[i] = temp;
                    marker += 1;
                }
            }
            //put pivot(array[end]) between left and right subarrays
            temp = Array[marker];
            Array[marker] = Array[end];
            Array[end] = temp;
            return marker;
        }

        public static void QuickSorting(string[] Array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int pivot = Partition(Array, start, end);
            QuickSorting(Array, start, pivot - 1);
            QuickSorting(Array, pivot + 1, end);
        }
    }
}
