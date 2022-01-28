using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms.AlgSortingWithoutGenerics
{
    class ShellSort
    {
        public static void ShellSorting(int[] Array)
        {
            int j;
            int step = Array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (Array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (Array[j] > Array[j + step]))
                    {
                        int tmp = Array[j];
                        Array[j] = Array[j + step];
                        Array[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
        public static void ShellSorting(string[] Array)
        {
            int j;
            int step = Array.Length / 2;
            while (step > 0)
            {
                for (int i = 0; i < (Array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (String.Compare(Array[j] ,Array[j + step])>0))
                    {
                        var tmp = Array[j];
                        Array[j] = Array[j + step];
                        Array[j + step] = tmp;
                        j -= step;
                    }
                }
                step = step / 2;
            }
        }
    }
}
