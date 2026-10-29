using System;
using System.IO;
using System.Collections.Generic;

namespace Pr_16
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "numbers.txt";
            int n = 15;

            try
            {
                WriteToFile(filePath, n);
                ReadAndCalculate(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при работе с файлом: " + ex.Message);
            }

            Console.ReadKey();
        }

        static void WriteToFile(string path, int count)
        {
            Random rnd = new Random();

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < count; i++)
                {
                    double number = rnd.NextDouble() * (10.10 - (-7.71)) + (-7.71);
                    number = Math.Round(number, 2);
                    sw.WriteLine(number);
                }
            }
        }

        static void ReadAndCalculate(string path)
        {
            List<double> numbers = new List<double>();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    numbers.Add(double.Parse(line));
                }
            }

            Console.WriteLine("Содержимое файла:");
            foreach (double num in numbers)
            {
                Console.Write($"{num:F2}  ");
            }
            Console.WriteLine();

            int firstPositiveIndex = -1;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 0)
                {
                    firstPositiveIndex = i;
                    break;
                }
            }

            if (firstPositiveIndex != -1)
            {
                Console.WriteLine($"\nПервое положительное: {numbers[firstPositiveIndex]:F2} (позиция {firstPositiveIndex + 1})");

                double sum = 0;
                for (int i = firstPositiveIndex + 1; i < numbers.Count; i++)
                {
                    sum += numbers[i];
                }
                Console.WriteLine($"Сумма элементов после него: {sum:F2}");
            }
            else
            {
                Console.WriteLine("\nПоложительных чисел в файле нет.");
            }
        }
    }
}