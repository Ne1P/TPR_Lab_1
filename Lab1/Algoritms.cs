using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Algoritms
    {
        public static void CriterionWald(int[,] data)
        {
            Console.WriteLine();
            Console.WriteLine("     Критерій Вальда");
            int[] temp = new int[3];

            int[] minimums = new int[3];
            Console.Write("Мінімальні значення з рядка: ");
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    temp[j] = data[i, j];
                }
                minimums[i] = temp.Min();
                Console.Write(minimums[i]+", ");
            }
            Console.WriteLine();

            int bestRow = 0;

            for (int i = 0; i < minimums.Count(); i++)
            {
                if (minimums.Max() == minimums[i])
                {
                    bestRow = i;
                    Console.WriteLine("Найбільше з цих значень: " + minimums.Max() + "  У рядку: " + (bestRow + 1));
                }
            }

            Console.Write("Найкраще рішення: ");
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[bestRow, j] + ", ");
            }
            Console.WriteLine();
        }

        public static void СriterionLaplace(int[,] data)
        {
            Console.WriteLine();
            
            Console.WriteLine("     Критерій Лапласа");

            double[] rowSum = new double[3];


            Console.Write("Просумовані значення з рядка: ");
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    rowSum[i] += data[i, j];
                }
                Console.Write(rowSum[i] + ", ");
            }
            Console.WriteLine();
            Console.Write("Розділені на к-ть рядків значення: ");
            for (int i = 0; i < rowSum.Count(); i++)
            {
                rowSum[i] = Math.Round((rowSum[i] / (data.GetLength(0))), 1);
                Console.Write(rowSum[i] + ", ");
            }
            Console.WriteLine();

            int bestRow = 0;

            for (int i = 0; i < rowSum.Count(); i++)
            {
                if (rowSum.Max() == rowSum[i])
                { 
                    bestRow = i;
                    Console.WriteLine("Найбільше з цих значень: "+rowSum.Max()+ "  У рядку: "+(bestRow+1));
                }
            }

            Console.Write("Найкраще рішення: ");
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[bestRow, j] + ", ");
            }
            Console.WriteLine();

        }

        public static void CriterionHurwitz(int[,] data)
        {
            Console.WriteLine();
            Console.WriteLine("     Критерій Гурвіца");
            SubCriterionHurwitz(data, 0.9);
            SubCriterionHurwitz(data, 0.2);
        }
        public static void SubCriterionHurwitz(int[,] data, double coeff)
        { 
            int[] maxInRow = new int[3];
            int[] minInRow = new int[3];

            Console.WriteLine("Коефіцієнт: "+ coeff);
            for (int i = 0; i < data.GetLength(0); i++)
            {
                minInRow[i] = 101;
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] > maxInRow[i])
                    {
                        maxInRow[i] = data[i, j];
                    }
                    if(data[i, j] < minInRow[i])
                    {
                        minInRow[i] = data[i, j];
                    }
                }
               
            }
            Console.Write("Максимуми рядків: ");
            for (int i = 0; i < maxInRow.Count(); i++)
            {
                Console.Write(maxInRow[i]+", ");
            }
            Console.WriteLine();
            Console.Write("Мінімуми рядків: ");
            for (int i = 0; i < minInRow.Count(); i++)
            {
                Console.Write(minInRow[i] + ", ");
            }
            Console.WriteLine();

            double[] matem = new double[3];

            Console.Write("Значеняя з формули - [k*min + (1-k)*max]: ");
            for(int i = 0; i < matem.Count(); i++)
            {
                matem[i] = (coeff * minInRow[i]) + ((1 - coeff) * maxInRow[i]);
                Console.Write(matem[i] + ", ");
            }
            Console.WriteLine();

            int bestRow = 0;

            for (int i = 0; i < matem.Count(); i++)
            {
                if (matem.Max() == matem[i])
                {
                    bestRow = i;
                    Console.WriteLine("Найбільше з цих значень: " + matem.Max() + "  У рядку: " + (bestRow + 1));
                }
            }

            Console.Write("Найкраще рішення: ");
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[bestRow, j] + ", ");
            }
            Console.WriteLine();

            Console.WriteLine();
        }

        public static void CriterionBayesLaplace(int[,] data)
        {
            Console.WriteLine();
            Console.WriteLine("     Критерій Байєса-Лапласа");

            double[] matem = new double[3];
            double[] coeff = new double[3];
            coeff[0] = 0.5;
            coeff[1] = 0.35;
            coeff[2] = 0.15;
            Console.Write("Значеняя з формули - [A1*k1 + A2*k2 + A3*k3]: ");

            for (int i = 0; i < data.GetLength(0); i++)
            {
                matem[i] = data[i, 0] * coeff[0] + data[i, 1] * coeff[1] + data[i, 2] * coeff[2];
                Console.Write(matem[i] + ", ");
            }
            Console.WriteLine();

            int bestRow = 0;

            for (int i = 0; i < matem.Count(); i++)
            {
                if (matem.Max() == matem[i])
                {
                    bestRow = i;
                    Console.WriteLine("Найбільше з цих значень: " + matem.Max() + "  У рядку: " + (bestRow + 1));
                }
            }

            Console.Write("Найкраще рішення: ");
            for (int j = 0; j < data.GetLength(1); j++)
            {
                Console.Write(data[bestRow, j] + ", ");
            }
            Console.WriteLine();


            Console.WriteLine();

        }
    }
}
