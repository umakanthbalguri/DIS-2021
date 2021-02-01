using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Spring2021
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 1, 3, 1, 5, 4 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" }};
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        private static void printTriangle(int n)
        {
            int a, b;
            //using try catch block to protect the program from running into errors
            try
            {
                //Using For loop to compute the numbers based on input number
                for (a = 0; a <= n; a++)
                {
                    for (b = 1; b <= n - a; b++) //if condition is true, it will go inside 
                    {
                        Console.Write(" "); //if condition is true, it will print space
                    }
                    for (b = 1; b <= 2 * a - 1; b++)
                    {
                        Console.Write("*"); //if condition is true, it will print *
                    }
                    Console.Write("\n");
                }
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }

        private static void printPellSeries(int n2)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //Creating an array of integers to hold calculated number series
                int[] series = new int[n2];

                //Using For loop to compute the numbers based on input number
                for (int a = 1; a < n2; a++)
                {
                    //using if conditon to print first 2 numbers of the series i.e 0,1. This is to protect the program from avoiding out of Range error
                    if (a < 2)
                    {
                        series[a] = a;
                    }
                    else
                    {
                        series[a] = (series[a - 1] * 2) + series[a - 2];
                    }
                }
                //using foreach statement to print all items in the array
                foreach (var item in series)
                {
                    Console.Write(item);
                    Console.Write(" ");
                }
            }
            //Catch block for error handling
            catch (Exception)
            {

                throw;
            }
        }


        private static bool squareSums(int n3)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                for (int a = 0; a * a <= n3; a++) //Using for loop validate the numbers less than or equal to input
                {
                    for (int b = 0; b * b <= n3; b++)
                    {
                        if (a * a + b * b == n3)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }


        private static int diffPairs(int[] nums, int k)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //Performing an input check
                if (nums == null || nums.Length == 0 || k < 0)
                {
                    return 0;
                }

                //Declaring variables 
                var pairs = new List<int[]>();
                var NumSet = new HashSet<int>();
                var NumExists = new HashSet<int>();

                //using for each loop to read through each variable in the declared loop
                foreach (var number in nums)
                {
                    // Calculating the number bigger than the number by the difference 
                    var BigNum = number + k;

                    // Calculating the number smaller than the number by the difference 
                    var SmallNum = number - k;

                    // Using HashSet.Contains to check if HashSet contains the number
                    if (NumSet.Contains(BigNum))
                    {
                        // Using HashSet.Contains checking if HashSet contains the bigger number
                        if (!NumExists.Contains(BigNum))
                        {
                            // Using List.Add method add the pair
                            pairs.Add(new int[] { BigNum, number });
                            NumExists.Add(BigNum);
                        }
                    }

                    if (NumSet.Contains(SmallNum))
                    {
                        if (!NumExists.Contains(number))
                        {
                            pairs.Add(new int[] { number, SmallNum });
                            NumExists.Add(number);
                        }
                    }

                    NumSet.Add(number);
                }

                return pairs.Count;
            }
            catch (Exception e)
            {
                //returning standard error message in case on invalid input
                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        private static int UniqueEmails(List<string> emails)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                //declaring variables
                bool fl = false;
                bool fl2 = false;
                List<string> result = new List<string>();
                //using for each loop to read through each string in the declared loop
                foreach (string value in emails)
                {
                    string curr = "";
                    //using second for each loop to read through each character in the declared loop
                    foreach (char ch in value)
                    {
                        //if condition block to obtaing appropriately formatted email addresses to  curr string
                        if (ch == '@') { fl2 = true; fl = false; curr += ch; }
                        if ((char.IsLetter(ch) || char.IsDigit(ch)) && !fl) { curr += ch; }
                        if (ch == '.' && fl2) { curr += ch; }
                        if (ch == '+' && !fl && !fl2) { fl = true; }
                    }
                    //adding formatted email addresses to  curr string
                    result.Add(curr);
                    //resetting curr, fl and fl2 values for next iteration of for each loop
                    curr = ""; fl = false; fl2 = false;
                }
                //using distint function to eliminate repeatead emails and store it in 'Final Result'
                List<string> finalresult = result.Distinct().ToList();
                //returning int finalresult.count which is number of unique email adderesses.
                return finalresult.Count();
            }
            //Catch block for error handling
            catch (Exception e)
            {
                Console.Write(e.Message);
                return 0;
            }
        }


        private static string DestCity(string[,] paths)
        {
            //using try catch block to protect the program from running into errors
            try
            {
                string temp = "";
                int length = paths.Length;
                for (int a = 0; a < length / 2; a++) //Using for loop for getting all Destination cities in dest
                {
                    string dest = paths[a, 1];
                    for (int b = 0; b < length / 2; b++) //Using another for loop for comparing source cities
                    {
                        if (dest == paths[b, 0]) //checking if destination city is in Source city, If not return that city as destination city
                        {
                            break;
                        }
                        else
                        {
                            temp = dest;
                        }
                    }
                }
                return temp;
            }
            //Catch block for error handling
            catch (Exception)
            {
                throw;
            }
        }
    }
}