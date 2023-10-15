using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ListTasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 1, 7, 4, 5, 6, 2, 8, 9 };
            List<double> doublenums = new List<double> { 3.1, 1.55, 7.223, 4.666, 5.777, 6.11, 2.22, 8.44, 9 };
            int secondMax = FindSecondMax(numbers);
            Console.WriteLine($"Второе максимальное значение: {secondMax}");

            int sum = SumEvenPositions(numbers);
            Console.WriteLine($"Сумма элементов на четных позициях: {sum}");

            RemoveOddNumbers(numbers);

            string s1 = "hello";
            string s2 = "olleh";
            bool isReverse = IsReverse(s1, s2);
            Console.WriteLine($"5. Строка s2 обратная s1: {isReverse}");
            PrintNumbersAboveAverage(doublenums);
            string filePath = @"C:\\Users\\User\\source\\repos\\ListTasks\\ListTasks\task.txt";
            ReversePrintFileContent(filePath);
            PrintWordsByType(filePath);
            string numFilePath = @"C:\\Users\\User\\source\\repos\\ListTasks\\ListTasks\numTest.txt";
            PrintNumbersByType(numFilePath);
        }
        static int FindSecondMax(List<int> numbers)
        {
            int max1 = int.MinValue;
            int max2 = int.MinValue;
            foreach (var num in numbers)
            {
                if (num > max1)
                {
                    max2 = max1;
                    max1 = num;
                }
                else if (num > max2 && num < max1)
                {
                    max2 = num;
                }
            }

            return max2;
        }

        static int SumEvenPositions(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i += 2)
            {
                sum += numbers[i];
            }

            return sum;
        }
        static void RemoveOddNumbers(List<int> numbers)
        {
            numbers.RemoveAll(num => num % 2 != 0);
        }
        static void PrintNumbersAboveAverage(List<double> numbers)
        {
            double sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }

            double average = sum / numbers.Count;

            Console.WriteLine("Элементы больше среднего арифметического:");
            foreach (var num in numbers)
            {
                if (num > average)
                {
                    Console.WriteLine(num);
                }
            }
        }
        static void ReversePrintFileContent(string filePath)
        {

                string[] lines = File.ReadAllLines(filePath);
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    string reversedLine = ReverseString(lines[i]);
                    Console.WriteLine(reversedLine);
                }


        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static bool IsReverse(string s1, string s2)
        {
            if (s1.Length != s2.Length)
            {
                return false;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[s2.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
        static void PrintWordsByType(string filePath)
        {

                string text = File.ReadAllText(filePath);
                char[] delimiters = { ' ', ',', '.', ';', ':', '\t', '\n', '\r' };
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine("Слова, начинающиеся с гласных букв:");
                foreach (var word in words)
                {
                    if (!string.IsNullOrEmpty(word) && IsVowel(word[0]))
                    {
                        Console.WriteLine(word);
                    }
                }

                Console.WriteLine("Слова, начинающиеся с согласных букв:");
                foreach (var word in words)
                {
                    if (!string.IsNullOrEmpty(word) && !IsVowel(word[0]))
                    {
                        Console.WriteLine(word);
                    }
                }
            
        }

        static bool IsVowel(char c)
        {
            return "АИОУЫЭаиоуыэ".IndexOf(c) != -1;
        }
        static void PrintNumbersByType(string filePath)
        {

                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (double.TryParse(line, out double num))
                    {
                        if (num > 0)
                        {
                            Console.WriteLine($"Положительные: {num}");
                        }
                        else if (num < 0)
                        {
                            Console.WriteLine($"Отрицательные: {num}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Числа: {line}");
                    }
                }
        }

        //2,4 и 8,9 идентичны 
    }
}
