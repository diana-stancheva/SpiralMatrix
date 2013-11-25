/*
 * Write a program that reads a positive integer number N (N < 20) from console and outputs in the console the numbers 1 ... N numbers arranged as a spiral.
 *	    Example for N = 4
 * 
 *      1  2  3  4
 *      12 13 14 5
 *      11 16 15 6
 *      10 9  8  7
 */

namespace _14PrintAMatrixArrangedAsASpiral
{
    using System;

    class PrintAMatrixArrangedAsASpiral
    {
        static void Main()
        {
            int n = 0;
            
            while (n < 1 || n > 20)
            {
                Console.Write("Enter N: ");
                n = int.Parse(Console.ReadLine());
            }

            int[,] matrix = new int[n, n]; 

            //Fill matrix with zeroz
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = 0;
                }
            }

            FillMatrix(n, matrix);
            PrintMatrix(n, matrix);

        }

        static void PrintMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0,4} ", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void FillMatrix(int n, int[,] matrix)
        {
            string flag = "right";
            int row = 0;
            int col = 0;

            for (int number = 1; number <= n * n; number++)
            {
                if (flag == "right" && (col > n - 1 || matrix[row, col] != 0))
                {
                    flag = "down";
                    col--;
                    row++;
                }

                if (flag == "down" && (row > n - 1 || matrix[row, col] != 0))
                {
                    flag = "left";
                    row--;
                    col--;
                }

                if (flag == "left" && (col < 0 || matrix[row, col] != 0))
                {
                    flag = "up";
                    col++;
                    row--;
                }

                if (flag == "up" && (row < 0 || matrix[row, col] != 0))
                {
                    flag = "right";
                    col++;
                    row++;
                }

                matrix[row, col] = number;

                if (flag == "right")
                {
                    col++;
                }
                if (flag == "down")
                {
                    row++;
                }
                if (flag == "left")
                {
                    col--;
                }
                if (flag == "up")
                {
                    row--;
                }
            }
        }
    }
}
