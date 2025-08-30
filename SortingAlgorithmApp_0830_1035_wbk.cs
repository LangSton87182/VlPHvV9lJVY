// 代码生成时间: 2025-08-30 10:35:22
 * The application allows users to choose a sorting algorithm and sort a list of integers.
 *
 * Author: [Your Name]
 * Date: [Date]
 */

using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SortingAlgorithmApp
{
    // Define a ViewModel class to handle sorting logic
    public class SortingViewModel
    {
        public List<int> Numbers { get; set; }
        public string SelectedAlgorithm { get; set; }
        public ICommand SortCommand { get; private set; }

        public SortingViewModel()
        {
            // Initialize with a list of sample numbers
            Numbers = new List<int> { 5, 3, 8, 1, 6, 4, 2, 7 };

            // Initialize the command to handle sorting
            SortCommand = new Command(ExecuteSortCommand);
        }

        // ExecuteSortCommand method that sorts the list based on the selected algorithm
        private void ExecuteSortCommand()
        {
            try
            {
                switch (SelectedAlgorithm)
                {
                    case "Bubble Sort":
                        Numbers = BubbleSort(Numbers);
                        break;
                    case "Quick Sort":
                        Numbers = QuickSort(Numbers);
                        break;
                    case "Merge Sort":
                        Numbers = MergeSort(Numbers);
                        break;
                    default:
                        throw new NotSupportedException($"Sorting algorithm '{SelectedAlgorithm}' is not supported.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions and show an error message
                Console.WriteLine($"Error sorting numbers: {ex.Message}");
            }
        }

        // Bubble Sort implementation
        private List<int> BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        // Swap elements
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }

        // Quick Sort implementation (recursive)
        private List<int> QuickSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int pivot = list[0];
            List<int> less = new List<int>();
            List<int> greater = new List<int>();
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i] < pivot)
                {
                    less.Add(list[i]);
                }
                else
                {
                    greater.Add(list[i]);
                }
            }
            return Concat(QuickSort(less), new List<int> { pivot }, QuickSort(greater));
        }

        // Merge Sort implementation (recursive)
        private List<int> MergeSort(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }

            int middle = list.Count / 2;
            List<int> left = MergeSort(list.GetRange(0, middle));
            List<int> right = MergeSort(list.GetRange(middle, list.Count - middle));
            return Merge(left, right);
        }

        // Helper method to merge two sorted lists
        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] < right[0])
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            result.AddRange(left);
            result.AddRange(right);
            return result;
        }

        // Helper method to concatenate three lists
        private List<int> Concat(List<int> first, List<int> second, List<int> third)
        {
            first.AddRange(second);
            first.AddRange(third);
            return first;
        }
    }
}
