using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.AlgSortingWithoutGenerics
{
   public class MergeSorting
    {
        static public void Merdge(int[] items , int [] left , int [] right)
        {
            int leftIndex = 0;

            int rightIndex = 0;

            int targetIndex = 0;

            int reamining = left.Length + right.Length;

            while (reamining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }
                targetIndex++;

                reamining--;
            }
        }
        public static void MergeSort(int[] items)
        {
          if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;

            int rightSize = items.Length - leftSize;

            int[] left = new int[leftSize];

            int[] right = new int[rightSize];

            Array.Copy(items, 0, left, 0, leftSize);

            Array.Copy(items, leftSize, right, 0, rightSize);

            MergeSort(left);

            MergeSort(right);

            Merdge(items, left, right);


        }

        static public void Merdge(string[] items, string[] left, string[] right)
        {
            int leftIndex = 0;

            int rightIndex = 0;

            int targetIndex = 0;

            int reamining = left.Length + right.Length; //общая длинна сортируемого массива

            while (reamining > 0)
            {
                //если дошли до конца левого массива ,то в результирующий массив записываем,оставшиеся элементы из правого массива
                if (leftIndex >= left.Length)
                {
                    items[targetIndex] = right[rightIndex++];
                }
                //если дошли до конца правого массива ,то в результирующий массив записываем,оставшиеся элементы из левого массива
                else if (rightIndex >= right.Length)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                //сравнение элементов 
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    items[targetIndex] = left[leftIndex++];
                }
                else
                {
                    items[targetIndex] = right[rightIndex++];
                }
                targetIndex++;

                reamining--;
            }
        }

        public static void MergeSort(string[] items)
        {
            if (items.Length <= 1)
            {
                return;
            }

            int leftSize = items.Length / 2;

            int rightSize = items.Length - leftSize;

            string[] left = new string[leftSize];

            string[] right = new string[rightSize];

            //заполнение левого массива
            Array.Copy(items, 0, left, 0, leftSize);
            //заполнение правого массива
            Array.Copy(items, leftSize, right, 0, rightSize);

            MergeSort(left);

            MergeSort(right);

            Merdge(items, left, right);


        }

        //static public int[] MergeSort(int[] array)
        //{
        //    return MergeSort(array, 0, array.Length - 1);
        //}
    }
}
