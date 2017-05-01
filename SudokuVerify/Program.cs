using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length;i++)
            {
                Verify(args[i]);
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
        static void Verify(string fn)
        {
            int[,] sudokuArray = new int[9, 9];
            bool isSudoku;
            string[] fileContent;
            string[] fileContentSlice;

                fileContent = System.IO.File.ReadAllLines(fn);
                for (int i = 0; i < 9; i++)
                {
                    fileContentSlice = fileContent[i].Split(' ').ToArray();
                    for (int j = 0; j < 9; j++)
                    {
                        sudokuArray[i,j] = int.Parse(fileContentSlice[j]);
                    }
                }
            isSudoku = true;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if ((sudokuArray[k, i] == sudokuArray[j, i]
                            || sudokuArray[i, k] == sudokuArray[i, j])
                            && k != j)
                        {
                            isSudoku = false;
                            break;
                        }
                    }
                }
            }

            if (isSudoku == true)
                Console.WriteLine("It is sudoku! Yay!");
            else
                Console.WriteLine("It is not sudoku. Sorry.");
        }
    }
}
