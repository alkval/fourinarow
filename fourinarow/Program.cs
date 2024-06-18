using System;

namespace fourinarow
{
    class Program
    {
        static string[,] boardString = new string[,]
        {
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"},
            {"O","O","O","O","O","O","O"}
        };
        
        public static int[,] board = new int[,]
        {
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0}
        };
        static int gameStatus = 0;

        static void Main(string[] args)
        {
            while (gameStatus == 0)
            {
                DrawBoard();
                gameStatus = CheckWin();
                if (gameStatus != 0)
                {
                    Console.WriteLine($"Player " + gameStatus + " wins!");
                    Console.WriteLine("Do you want to play again? (y/n)");
                    string playAgain = Console.ReadLine();
                    if (playAgain == "y")
                    {
                        gameStatus = 0;
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 7; j++)
                            {
                                board[i,j] = 0;
                            }
                        }
                        Main(args);
                    }
                    else
                    {
                        break;
                    }
                    

                    break;
                }
                Player.PlayerMove();
                Player.turn += 1;
            }

        }
        static void DrawBoard()
            {
                Console.Clear();
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (board[i,j] == 1)
                        {
                            boardString[i,j] = "\x1b[91m■\x1b[39m";
                        }
                        else if (board[i,j] == 2)
                        {
                            boardString[i,j] = "\x1b[96m■\x1b[39m";
                        }
                        Console.Write(" " + boardString[i,j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine(" -------------");
                Console.WriteLine(" 1 2 3 4 5 6 7");
            }
        static int CheckWin()
        {
            if (CheckHorizontal() != 0)
            {
                return CheckHorizontal();
            }
            else if (CheckVertical() != 0)
            {
                return CheckVertical();
            }
            else if (CheckDiagonal() != 0)
            {
                return CheckDiagonal();
            }
            else
            {
                return 0;
            }
        }

        static int CheckHorizontal()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i,j] == 1 && board[i,j+1] == 1 && board[i,j+2] == 1 && board[i,j+3] == 1)
                    {
                        return 1;
                    }
                    else if (board[i,j] == 2 && board[i,j+1] == 2 && board[i,j+2] == 2 && board[i,j+3] == 2)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        static int CheckVertical()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i,j] == 1 && board[i+1,j] == 1 && board[i+2,j] == 1 && board[i+3,j] == 1)
                    {
                        return 1;
                    }
                    else if (board[i,j] == 2 && board[i+1,j] == 2 && board[i+2,j] == 2 && board[i+3,j] == 2)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }

        static int CheckDiagonal()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (board[i,j] == 1 && board[i+1,j+1] == 1 && board[i+2,j+2] == 1 && board[i+3,j+3] == 1)
                    {
                        return 1;
                    }
                    else if (board[i,j] == 2 && board[i+1,j+1] == 2 && board[i+2,j+2] == 2 && board[i+3,j+3] == 2)
                    {
                        return 2;
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 7; j++)
                {
                    if (board[i,j] == 1 && board[i+1,j-1] == 1 && board[i+2,j-2] == 1 && board[i+3,j-3] == 1)
                    {
                        return 1;
                    }
                    else if (board[i,j] == 2 && board[i+1,j-1] == 2 && board[i+2,j-2] == 2 && board[i+3,j-3] == 2)
                    {
                        return 2;
                    }
                }
            }
            return 0;
        }
        

    }

    class Player
    {
        public static int turn = 0;
        public int playerNumber;
        public Player(int playerNumber)
        {
            this.playerNumber = playerNumber;
        }

        static Player player1 = new Player(1);
        static Player player2 = new Player(2);

        public static void PlayerMove()
        {
            
            if (turn % 2 == 0)
            {
                Console.WriteLine("Player 1 make your move (1-7)");
            int move = Convert.ToInt32(Console.ReadLine());
            if (move < 1 || move > 7)
            {
                Console.WriteLine("Invalid move");
                PlayerMove();
            }
            else
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (Program.board[i,move-1] == 0)
                    {
                        Program.board[i,move-1] = 1;
                        break;
                    }
                }
            }
            }
            else
            {
                Console.WriteLine("Player 2 make your move (1-7)");
            int move = Convert.ToInt32(Console.ReadLine());
            if (move < 1 || move > 7)
            {
                Console.WriteLine("Invalid move");
                PlayerMove();
            }
            else
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (Program.board[i,move-1] == 0)
                    {
                        Program.board[i,move-1] = 2;
                        break;
                    }
                }
            }
            }
            
            
        }
    }
}