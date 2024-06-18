using System;

namespace fourinarow
{
    class Program
    {
        readonly static string[,] board = new string[,]
        {
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"}
        };
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Clear();
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(" " + board[i,j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine(" -------------");
            Console.WriteLine(" 1 2 3 4 5 6 7");
            Console.ReadKey();
        }

        
    }
}