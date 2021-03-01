﻿using System;
using System.Collections.Generic;

namespace Assignment2_DIS_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        ///<summary>
        ///Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        ///</summary>

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                int[] result = new int[2 * n];
                int l = 0;
                for (int i = 0; i < n; i++)
                {
                    // getting the first element from the first half
                    result[l++] = nums[i];
                    // getting the second element from the second half
                    result[l++] = nums[i + n];
                }

                foreach (var item in result)
                {
                    item.ToString();
                }
                Console.Write("[{0}]", string.Join(", ", result));
                Console.Write("\n\n");
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                int m = 0;
                int n = 0;

                // finding the first occurence of 0
                while (m < ar2.Length && ar2[m] != 0)
                {
                    m++;
                }
                // If edge case: no 0 present then print to console and return 
                if (m == ar2.Length)
                {
                    // Write the output to console when no 0 is present
                    for (int l = 0; l < ar2.Length; l++)
                    {
                        Console.Write(ar2[l] + " ");
                    }
                    return;
                }
                // Recording the first occurence of 0
                n = m;
                // The index will search for non-zero numbers after the first occurence of zero
                m = n + 1;
                while (m < ar2.Length)
                {
                    // if current element is 0 then see the next element
                    if (ar2[m] == 0)
                    {
                        m++;
                    }
                    else
                    {
                        // Put current element in the position having index y
                        ar2[n++] = ar2[m++];
                    }
                }
                // rest other position should have 0
                while (n < ar2.Length)
                {
                    ar2[n++] = 0;
                }
                foreach (var item in ar2)
                {
                    item.ToString();
                }
                Console.Write("[{0}]", string.Join(", ", ar2));
                Console.WriteLine();
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        // time complexity = O(n)


        private static void CoolPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> pair = new Dictionary<int, int>();
                // store the count of distinct elements in dictionary
                for (int i = 0; i < nums.Length; i++)
                {
                    if (pair.ContainsKey(nums[i]))
                    {
                        pair[nums[i]] += 1;
                    }
                    else
                    {
                        pair.Add(nums[i], 1);
                    }
                }
                // calculating the number of cool pairs possible with each distinct value and sum them up  
                Dictionary<int, int>.KeyCollection keyColl = pair.Keys;
                int total = 0;
                foreach (int s in keyColl)
                {
                    total += (pair[s] * (pair[s] - 1) / 2);
                }
                // Writing the output to console
                Console.WriteLine(total);
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>


        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> indices = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    // checking if targe element is present in the array
                    if (indices.ContainsKey(target - nums[i]))
                    {
                        // writing the output to console
                        Console.WriteLine("[" + indices[target - nums[i]] + "," + i + "]");
                        break;
                    }
                    // else,  add the <K,V> pair in the dictionary
                    indices.Add(nums[i], i);
                }
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>

        // time complexity = O(n)

        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                int l = s.Length;
                Dictionary<int, String> str = new Dictionary<int, String>();
                // creating the dictionary
                for (int i = 0; i < l; i++)
                {
                    str.Add(indices[i], s[i].ToString());
                }
                string output = "";
                // building the string by querying the dictionary with the index values.
                for (int i = 0; i < l; i++)
                {
                    output += str[i];
                }
                Console.WriteLine(output);
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>


        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                Dictionary<char, char> iso = new Dictionary<char, char>();
                // edge case: if the two array are of unequal length then there is no point in checking further
                if (s1.Length != s2.Length)
                {
                    return false;
                }
                int i = 0;
                while (i < s1.Length)
                {
                    // 2 different keys can not be mapped to the same values.
                    if (!(iso.ContainsKey(s1[i]) || iso.ContainsValue(s2[i])))
                    {
                        iso.Add(s1[i], s2[i]);
                    }
                    else
                    {
                        // if the key is not present or the value does not match,
                        // Strings can not be isomorphic to each other
                        if (!iso.ContainsKey(s1[i]) || iso[s1[i]] != s2[i])
                        {
                            return false;
                        }
                    }
                    i++;
                }
                return true;
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>


        private static void HighFive(int[,] items)
        {
            try
            {
                List<int[]> l = new List<int[]>();
                List<int[,]> result = new List<int[,]>();
                // converting it to list so that, we can use delegates and lambda expression and sort
                for (int i = 0; i < items.GetLength(0); i++)
                {
                    l.Add(new int[] { items[i, 0], items[i, 1] });
                }
                // sorting the list
                l.Sort((a, b) => { return (a[0] < b[0]) ? -1 : ((a[0] == b[0]) ? ((a[1] <= b[1]) ? 1 : -1) : 1); });
                int m = l[0][0];
                int c = 1;
                int s = l[0][1];

                // taking the top 5 entries of every id and computing its sum
                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i][0] == m && c < 5)
                    {
                        s += l[i][1];
                        c += 1;
                    }
                    else if (l[i][0] != m)
                    {
                        result.Add(new int[,] { { m, s / 5 } });

                        Console.Write("[[" + m + "," + s / 5 + "]" + ",");
                        m = l[i][0];
                        c = 1;
                        s = l[i][1];
                    }
                }
                result.Add(new int[,] { { m, s / 5 } });
                Console.Write("[" + m + "," + s / 5 + "]]");
                Console.Write("\n");
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>


        private static HashSet<int> store = new HashSet<int>();
        private static bool HappyNumber(int x)
        {
            try
            {
                // storing into hashset
                store.Add(x);
                // if n=1 its a happoy number
                if (x == 1)
                {
                    return true;
                }

                // computing sum of squares of the digit
                int sum = 0;
                while (x > 0)
                {
                    int d = x % 10;
                    sum += Convert.ToInt32(Math.Pow(d, 2));
                    x = x / 10;
                }
                // checking if the value is already there in the hashset, then it is not a happy number
                if (!store.Contains(sum))
                {
                    return HappyNumber(sum);
                }
                return false;
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        // time complexity = O(n)

        private static int Stocks(int[] prices)
        {
            try
            {
                int maxpri = 0;
                int s = prices.Length - 1;
                int b = s - 1;

                // traverse backwards: buy and sell are carrying index numbers
                while (b >= 0)
                {
                    // set the new sell index when value at buy 
                    //index is more than the value at the sell index 
                    if (prices[b] > prices[s])
                    {
                        s = b;
                        b = s - 1;
                    }
                    else
                    {
                        // calculating the running profit and compare it with the max so far
                        maxpri = Math.Max(maxpri, prices[s] - prices[b]);
                        b--;
                    }
                }
                return maxpri;
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>


        private static void Stairs(int n)
        {
            try
            {
                int output = 0;
                // for step 0;
                int x = 1;
                // for step 1
                int y = 1;
                // if n<=1 we do not have to compute any other value
                if (n <= 1)
                {
                    output = 1;
                }
                // to reduce space complexity storing only the last two values
                for (int i = 2; i <= n; i++)
                {
                    x = x + y;
                    //swapping a and b
                    int temp = x;
                    x = y;
                    y = temp;
                }
                output = y;
                // writing the output to console
                Console.WriteLine(output);
            }
            // Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }
    }
}