using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class vscode
    {
        public static string GetStudNumber(string student, DateTime date, int group)
        {
            var FullName = student.Split(' ');
            return $"{date.ToString("yyyy")}.{group}.{FullName[0]} {FullName[1].Substring(0, 1)}.{FullName[2].Substring(0, 1)}";
        }
        public void add(int a, int b)
        {
            IEnumerable<int> nums = Enumerable.Range(a, b);
            Console.WriteLine("Последовательность чисел: \n");

            foreach (int i in nums)
                Console.Write(i);
            foreach (int k in nums)
                Console.Write(k);

            double average = nums.Average();
            double min = nums.Min();
            Console.WriteLine("\n\nСреднее арифметическое: " + average);
            Console.WriteLine("\n\nМеньшее арифметическое: " + min);
        }
    }
} 
