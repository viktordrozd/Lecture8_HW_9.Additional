using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lecture8_HW_9.Additional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //implement IComparable interface

            //I can implement something like described here https://learn.microsoft.com/en-US/troubleshoot/developer/visualstudio/csharp/language-compilers/use-icomparable-icomparer
            //But I can't understad how it can be used in the below problems.




            //Write a program in C# Sharp to display the list of items in the array according to the length of the string then by name in ascending order. 
            //LINQ : Display the list according to the length then by name in ascending order :
            //--------------------------------------------------------------------------------
            //The cities are : 'ROME','LONDON','NAIROBI','CALIFORNIA','ZURICH','NEW DELHI','AMSTERDAM','ABU DHABI','PARIS'

            //Here is the arranged list :
            //ROME
            //PARIS
            //LONDON
            //ZURICH
            //NAIROBI
            //ABU DHABI
            //AMSTERDAM
            //NEW DELHI
            //CALIFORNIA

            var cities = new string[] { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };

            var res = SortByLengthThenAlpha(cities);
            foreach (var c in res)
            {
                Console.WriteLine(c);
            }


            //Write a program in C# Sharp to arrange the distinct elements in the list in ascending order. 
            //LINQ : Arrange distinct elements in the list in ascending order : 
            // ----------------------------------------------------------------
            // Biscuit
            //Brade
            //Butter
            //Honey


            Console.WriteLine("================================================================");
            var food = new List<string> { "Sandwich","Biscuit", "Brade", "Butter", "Honey", "Jam", "Brade", "Juice", "IceCream", "Biscuit" };

            var res1 = SortDistinctValues(food);
            
            foreach (var c in res1) 
            {
                Console.WriteLine(c);
            }


            //Write a program in C# Sharp to find the strings for a specific minimum length. 
            //LINQ : Find the strings for a specific minimum length :
            // ------------------------------------------------------
            // Input number of strings to store in the array :3
            // Input 3 strings for the array :
            // Element[0] : Welcome
            // Element[1] : to
            // Element[2] : https://classroom.google 
            //Input the minimum length of the item you want to find : 10
            // The items of minimum 10 characters are :
            //Item: https://classroom.google

            Console.WriteLine("Please enter the number of strings (valid integer): ");
            //Quick and dirty without proper user input handling.
            var arrayLength = int.Parse(Console.ReadLine());

            var array = new string[arrayLength];

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Please enter the {i+1} string (valid string): ");
                array[i] = Console.ReadLine();
            }

            Console.WriteLine($"The longest string is: " + GetTheLongestStringFromArray(array));

        }

        public static string[] SortByLengthThenAlpha(string[] array)
        {
            var sorted = from arrEl in array
                         orderby arrEl.Length, arrEl ascending
                         select arrEl;

            return sorted.ToArray();

        }

        public static List<string> SortDistinctValues(List<string> list) 
        {
            var sorted = list.OrderBy(x => x).Distinct().ToList();
            return sorted;
        }

        public static string GetTheLongestStringFromArray(string[] array)
        {
            var sortedByLength = array.OrderBy(x => x.Length).OrderDescending().ToArray();
            return sortedByLength.First().ToString();
        }
    }
}
