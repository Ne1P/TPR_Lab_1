using System;
using System.IO;
using System.Text;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var data = ReadData();

            PrintData(data); // Вивід масиву на екран

            Algoritms.CriterionWald(data);
            Algoritms.СriterionLaplace(data);
            Algoritms.CriterionHurwitz(data);

            Algoritms.CriterionBayesLaplace(data);

            Console.ReadLine();
        }

        public static int[,] ReadData()
        {
            string[] lines = File.ReadAllLines(@"C:\Users\Petro\Desktop\Algoritm\TPR\Lab_1\data.txt");
            int[,] num = new int[lines.Length, lines[0].Split(' ').Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    num[i, j] = Convert.ToInt32(temp[j]);
            }
            // проверяем выводом на консоль
            return num;
        }

        public static void PrintData(int[,] data)
        {
            Console.WriteLine("   Вхідні дані:");
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    Console.Write(data[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
