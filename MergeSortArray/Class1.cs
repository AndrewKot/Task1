using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortArray
{
    public class LogicInterface
    {
        public static List<int> MergeSort(List<int> unsorted)
        {
            List<int> sorted = new List<int> { };

            if (unsorted.Count <= 1)
            {
                sorted = unsorted;
                return sorted;
            }

            int midle = unsorted.Count / 2;

            List<int> Left = new List<int> { };
            List<int> Right = new List<int> { };

            for (int i = 0; i < midle; i++)
            {
                Left.Add(unsorted[i]);
            }

            for (int i = midle; i < unsorted.Count; i++)
            {
                Right.Add(unsorted[i]);
            }

            Left = MergeSort(Left);
            Right = MergeSort(Right);

            return Merge(Left, Right);
        }
        public static List<int> Merge(List<int> Left, List<int> Right)
        {
            List<int> result = new List<int> { };

            while (Left.Count != 0 && Right.Count != 0)
            {
                if (Left[0] >= Right[0])
                {
                    result.Add(Right[0]);
                    Right.Remove(Right[0]);
                }
                else
                {
                    result.Add(Left[0]);
                    Left.Remove(Left[0]);
                }
            }

            if (Left.Count == 0)
            {
                result.AddRange(Right);
            }
            else
            {
                result.AddRange(Left);
            }

            return result;
        }
    }
}
