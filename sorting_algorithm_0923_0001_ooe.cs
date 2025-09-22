// 代码生成时间: 2025-09-23 00:01:00
using System;
using System.Collections.Generic;

namespace SortingAlgorithm
{
    /// <summary>
    /// Class for implementing sorting algorithms.
    /// </summary>
    public static class SortingHelper
    {
        /// <summary>
        /// Sorts an array of integers using the Bubble Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void BubbleSort(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            bool swapped;
            for (int i = 0; i < array.Length - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap elements
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                // If no two elements were swapped by inner loop, then break
                if (!swapped)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers using the Quick Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void QuickSort(int[] array, int low, int high)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length <= 1 || low >= high) return;

            int pivot = array[high];
            int i = (low - 1);
            for (int j = low; j < high; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            int temp = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp;

            QuickSort(array, low, i);
            QuickSort(array, i + 2, high);
        }

        /// <summary>
        /// Sorts an array of integers using the Merge Sort algorithm.
        /// </summary>
        /// <param name="array">The array to be sorted.</param>
        public static void MergeSort(int[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (array.Length <= 1) return;

            int mid = array.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            MergeSort(left);
            MergeSort(right);

            Merge(array, left, right);
        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };
            Console.WriteLine("Original array: " + string.Join(", ", array));

            SortingHelper.BubbleSort(array);
            Console.WriteLine("Sorted array (Bubble Sort): " + string.Join(", ", array));

            int[] array2 = new int[array.Length];
            Array.Copy(array, array2, array.Length);
            SortingHelper.QuickSort(array2, 0, array2.Length - 1);
            Console.WriteLine("Sorted array (Quick Sort): " + string.Join(", ", array2));

            int[] array3 = new int[array.Length];
            Array.Copy(array, array3, array.Length);
            SortingHelper.MergeSort(array3);
            Console.WriteLine("Sorted array (Merge Sort): " + string.Join(", ", array3));
        }
    }
}