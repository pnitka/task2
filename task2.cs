/*
using System;

namespace MaximumSubarraySum
{
    class Program
    {
        public static int[] MaxSubArray(int[] nums)
        {
            int maxSum = nums[0];
            int currentSum = nums[0];
            int start = 0, end = 0, tempStart = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (currentSum < 0)
                {
                    currentSum = nums[i];
                    tempStart = i;
                }
                else
                {
                    currentSum += nums[i];
                }

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    start = tempStart;
                    end = i;
                }
            }
            int[] result = new int[end - start + 1];
            Array.Copy(nums, start, result, 0, result.Length);
            return result;
        }

        static void Main(string[] args)
        {
            int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int[] maxSubArray = MaxSubArray(nums);
            Console.WriteLine("Подмассив с максимальной суммой: " + string.Join(", ", maxSubArray));
        }
    }
}
*/
using System;
using System.Collections.Generic;

namespace UniquePermutations
{
    class Program
    {
        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums); 
            Backtrack(result, new List<int>(), nums, new bool[nums.Length]);
            return result;
        }

        private static void Backtrack(List<IList<int>> result, List<int> tempList, int[] nums, bool[] used)
        {
            if (tempList.Count == nums.Length)
            {
                result.Add(new List<int>(tempList));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i]) continue;

                if (i > 0 && nums[i] == nums[i - 1] && !used[i - 1]) continue;

                used[i] = true;
                tempList.Add(nums[i]);
                Backtrack(result, tempList, nums, used);
                used[i] = false;
                tempList.RemoveAt(tempList.Count - 1);
            }
        }

        static void Main(string[] args)
        {
            int[] nums = { 1, 1, 2 };
            var permutations = PermuteUnique(nums);
            Console.WriteLine("Все уникальные перестановки:");
            foreach (var perm in permutations)
            {
                Console.WriteLine(string.Join(", ", perm));
            }
        }
    }
}
