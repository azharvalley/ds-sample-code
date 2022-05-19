using MyExceptionLibrary;
using System;
using System.Linq;

namespace DS
{
    class Program
    {
        static void Main(string[] args)
        {

            //StringInerpolation.BestUsages();

            #region Exception Handling
            DemoCode demoCode = new DemoCode();
            try
            {
                int numResult = demoCode.GrandParentMethod(6);
                Console.WriteLine($"The value at the position is {numResult}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("This is bad argument!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.GetType());
                var inner = ex.InnerException;

                while (inner != null)
                {
                    Console.WriteLine(inner.StackTrace);
                    Console.WriteLine(inner.GetType());
                    inner = inner.InnerException;
                }
            }
            #endregion


            Console.WriteLine(">>>>>>>>> Hey, this is Data Structures problems <<<<<<\n");
            Console.WriteLine("Enter 1 to run MaxConsecutivesOnes\n" +
                              "Enter 2 to run Find Numbers with Even Number of Digits\n" +
                              "Enter 3 to run Squares of a Sorted Array\n" +
                              "Enter 4 to run DuplicateZeros\n" +
                              "Enter 5 to tun MergeAndSort\n" +
                              "Enter 6 to run CheckIfExist\n" +
                              "Enter 7 to run ValidMountainArray\n" +
                              "Enter 8 to run SquareEvenIndexedElements\n" +
                              "Enter 9 to run ReplaceElements\n" +
                              "Enter 10 to run RemoveDuplicates");

            int.TryParse(Console.ReadLine(), out int result);
            Console.WriteLine($"You entered: {result}");
            switch (result)
            {
                case 0:
                    Console.WriteLine("Enter a valid number to run the code");
                    break;
                case 1:
                    int[] nums1 = new int[6];
                    nums1[0] = 1;
                    nums1[1] = 1;
                    nums1[2] = 0;
                    nums1[3] = 1;
                    nums1[4] = 1;
                    nums1[5] = 1;
                    Console.Write("Input: nums = ");
                    foreach (int item in nums1)
                    {
                        Utils.WriteInput($"{item} ");
                    }
                    int maxOnes = FindMaxConsecutiveOnes(nums1);
                    Console.WriteLine($"\nMax Consecutive Ones in 'nums' array is: {maxOnes}");
                    break;
                case 2:
                    int[] nums2 = { 12, 345, 2, 6, 7896 };
                    Console.Write("Input: nums = ");
                    foreach (int item in nums2)
                    {
                        Utils.WriteInput($"{item} ");
                    }
                    int evenDigits = FindNumbers(nums2);
                    Console.WriteLine($"\nEven number of digits in array nums: {evenDigits}");
                    break;
                case 3:
                    int[] nums3 = { -4, -1, 0, 3, 10 };
                    Console.Write("Input: nums = ");
                    foreach (int item in nums3)
                    {
                        Utils.WriteInput($"{item} ");
                    }
                    int[] sortedSqrd = SortedSquares(nums3);
                    Console.Write($"\nSorted Squares Array: ");
                    foreach (int item in sortedSqrd)
                    {
                        Utils.WriteOutput($"{item} ");
                    }
                    break;
                case 4:
                    int[] nums4 = new int[9];
                    nums4[0] = 0;
                    nums4[1] = 4;
                    nums4[2] = 1;
                    nums4[3] = 0;
                    nums4[4] = 0;
                    nums4[5] = 8;
                    nums4[6] = 0;
                    nums4[7] = 0;
                    nums4[8] = 3;
                    DuplicateZeros(nums4);
                    break;
                case 5:
                    int[] nums1s = { 1, 2, 3, 0, 0, 0 };
                    int[] nums2s = { 2, 5, 6 };
                    int m = 3; int n = 3;
                    MergeAndSort(nums1s, m, nums2s, n);
                    break;
                case 6:
                    int[] num6 = {-2,0,10,-19,4,6,-8};
                    bool IsTrue = CheckIfExist(num6);
                    Console.WriteLine($"Search found : {IsTrue}");
                    break;
                case 7:
                    int[] num7 = { 2, 0, 2 };
                    Console.WriteLine($"ValidMountainArray : {ValidMountainArray(num7)}");
                    break;
                case 8:
                    SquareEvenIndexedElements();
                    break;
                case 9:
                    int[] num9 = { 17, 18, 5, 4, 6, 1 };
                    Console.Write("Input: num9 = ");
                    foreach (int item in num9)
                    {
                        Utils.WriteInput($"{item} ");
                    }
                    int[] result9 = ReplaceElements(num9);
                    Console.Write($"\nReplace Elements with Greatest Element on Right Side: ");
                    foreach (int item in result9)
                    {
                        Utils.WriteOutput($"{item} ");
                    }
                    break;
                case 10:
                    int[] num10 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
                    Console.Write("Input: num10 = ");
                    foreach (int item in num10)
                    {
                        Utils.WriteInput($"{item} ");
                    }
                    int result10 = RemoveDuplicates(num10);
                    // Return k after placing the final result in the first k slots of nums.
                    Console.WriteLine($"\nReturn k after placing the final result in the first k slots of nums: {result10}");
                    break;
                default:
                    Console.WriteLine("Enter a valid number to run the code");
                    break;
            }
        }

        // Max Consecutive Ones
        // Given a binary array nums, return the maximum number of consecutive 1's in the array.
        public static int FindMaxConsecutiveOnes(int[] numbers)
        {
            int count = 0;
            int[] totalConsecutiveOnes = new int[5];
            int k = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 1)
                {
                    totalConsecutiveOnes[k] = ++count;
                }
                else
                {
                    k++;
                    count = 0;
                }
            }

            //Get max number in array
            return totalConsecutiveOnes.Max();
        }

        // Find Numbers with Even Number of Digits
        // Given an array nums of integers, return how many of them contain an even number of digits.
        public static int FindNumbers(int[] nums)
        {
            int evenDigits = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // Find digit of each items
                int totalDigit = 0;
                for (int j = 0; j < nums[i].ToString().Length; j++)
                {
                    totalDigit++;
                }
                // Find if totalDigit is even number
                if (totalDigit % 2 == 0)
                {
                    evenDigits++;
                }
            }
            return evenDigits;
        }

        // Squares of a Sorted Array
        // Given an integer array nums sorted in non-decreasing order, return an array of the squares of each number sorted in non-decreasing order.
        public static int[] SortedSquares(int[] nums)
        {
            // Square the array
            int[] sqrNums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                sqrNums[i] = nums[i] * nums[i];
            }
            Array.Sort(sqrNums);
            return sqrNums;
        }

        public static void DuplicateZeros(int[] arr)
        {

            // Find empty indexes in the end of arr
            int emptyIndexes = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == 0)
                {
                    emptyIndexes++;
                }
                else
                {
                    break;
                }
            }

            int arrItemLength = arr.Length - emptyIndexes;// This is Length of the arr Items
            int totalZeros = 0;
            // Find all possible zeros;
            for (int i = 0; i < arrItemLength; i++)
            {
                if (arr[i] == 0)
                {
                    totalZeros++;
                }
                // Final output in the arr should not exceed total Lenght of 8 items.
                // So max 2 possible duplicate zeros is allowed.
                if (arrItemLength >= 8)
                {
                    if (totalZeros == 2)
                    {
                        break;
                    }
                }
                
            }

            if (totalZeros > 0)
            {
                // Shift array element to right starting from (arr.Length-1) - totalZeros
                int shiftBy = totalZeros;
                int dupAt = totalZeros - 1;
                for (int i = (arr.Length - 1) - totalZeros; i >= 0; i--)
                {
                    arr[i + shiftBy] = arr[i];
                    if (arr[i] == 0)
                    {
                        arr[i + dupAt] = 0;
                        if(shiftBy > 0)
                        {
                            shiftBy--;
                        }                        
                        if (dupAt > 0)
                        {
                            dupAt--;
                        }
                    }
                }

            }


        }

        // Merge and Sort Array
        public static void MergeAndSort(int[] nums1, int m, int[] nums2, int n)
        {
            Console.Write("Input: nums1 = ");
            foreach (int item in nums1)
            {
                Utils.WriteInput($"{item} ");
            }
            Console.Write("Input: nums2 = ");
            foreach (int item in nums2)
            {
                Utils.WriteInput($"{item} ");
            }

            int nums1Length = m + n;
            int j = 0;
            for (int i = m; i < nums1Length; i++)
            {
                nums1[i] = nums2[j];
                j++;
            }
            Array.Sort(nums1);

            Console.Write($"\nMerged and Sorted Array: ");
            foreach (int item in nums1)
            {
                Utils.WriteOutput($"{item} ");
            }
        }

        // Check If N and Its Double Exist
        // Given an array arr of integers, check if there exists two integers N and M such that N is the double of M ( i.e. N = 2 * M).
        public static bool CheckIfExist(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i != j && arr[i] == 2 * arr[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Valid Mountain Array
        public static bool ValidMountainArray(int[] arr)
        {
            bool flag = false;
            if (arr.Length >= 3)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    int sdf = arr.Length / 2;
                    if (arr[i] < arr[i + 1] && i <= arr.Length / 2)
                    {
                        flag = true;
                    }
                    else
                    {
                        if (arr[i] > arr[i + 1] && i > arr.Length / 2)
                        {
                            flag = true;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        // Given an Array of integers, return an Array where every element at an even-indexed position is squared.
        public static void SquareEvenIndexedElements()
        {
            int[] arr = { 9, -2, -9, 11, 56, -12, -3 };
            Console.Write("Input: arr = ");
            foreach (int item in arr)
            {
                Utils.WriteInput($"{item} ");
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if(i % 2 == 0)
                {
                    arr[i] = arr[i] * arr[i];
                }
            }

            Console.Write($"\nSquare items at even indexed: ");
            foreach (int item in arr)
            {
                Utils.WriteOutput($"{item} ");
            }
        }

        // Replace Elements with Greatest Element on Right Side
        public static int[] ReplaceElements(int[] arr)
        {
            int length = arr.Length - 1;
            for (int i = 0; i < length; i++)
            {
                int greatestElementToRight = arr[i + 1];
                for (int j = i+2; j < arr.Length; j++)
                {
                    if (arr[j] > greatestElementToRight)
                    {
                        greatestElementToRight = arr[j];
                    }
                }
                arr[i] = greatestElementToRight;
            }
            arr[length] = -1;
            return arr;
        }

        public static int RemoveDuplicates(int[] nums)
        {
            int length = nums.Length;
            int newLength = length;
            if (length == 0) return 0;
            int k = 1;//Return length of unique items after removing duplicates.
            for (int i = 0; i < newLength - 1; i++)
            {
                for (int j = i+1; j < newLength; j++)
                {
                    if (nums[i] == nums[j])
                    {
                        // if items matches then shift right each items which will replace one duplicate item.
                        //for (int m = j; m < newLength - 1; m++)
                        //{
                            if (j < newLength - 1)
                            {
                                nums[j] = nums[j + 1];
                            }
                        //}
                        newLength--;
                        k++;
                    }
                }
            }
            Console.Write($"\nRemove Duplicates from Sorted Array: ");
            foreach (int item in nums)
            {
                Utils.WriteOutput($"{item} ");
            }
            return k;
        }

    }
}
