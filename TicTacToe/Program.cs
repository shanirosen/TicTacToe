using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {

            string huPlayer = "O";
            string aiPlayer = "X";
            string[] board = new string[] {
                "X", "X", "O",
                "", "X", "",
                "X", "O", "O"};

            /*
            printDemo();
            Console.WriteLine("YOU ARE O!");


            while (!winning(origBoard, huPlayer) && !winning(origBoard, aiPlayer) && origBoard.Contains(null))
            {
                Console.WriteLine("enter a number (index 0->8): ");
                int s = int.Parse(Console.ReadLine());
                if (origBoard[s] == null)
                {
                    origBoard[s] = "O";
                }
                else
                {
                    Console.WriteLine("this spot is taken");
                    continue;
                }
                bestSpot = minimax(origBoard, aiPlayer);

                origBoard[bestSpot.GetIndex()] = "X";
                printTicTacToe(origBoard);
            }*/

        }

        public static void printTicTacToe(string[] origBoard)
        {
            Console.Write(" " + origBoard[0] + " |");
            Console.Write(" " + origBoard[1] + " |");
            Console.Write(" " + origBoard[2] + " ");
            Console.WriteLine();
            Console.Write("-----------");
            Console.WriteLine();
            Console.Write(" " + origBoard[3] + " |");
            Console.Write(" " + origBoard[4] + " |");
            Console.Write(" " + origBoard[5] + " ");
            Console.WriteLine();
            Console.Write("-----------");
            Console.WriteLine();
            Console.Write(" " + origBoard[6] + " |");
            Console.Write(" " + origBoard[7] + " |");
            Console.Write(" " + origBoard[8] + " ");
            Console.WriteLine();
        }

        public static void printDemo()
        {
            Console.WriteLine("Board:");
            Console.Write(" " + 0 + " |");
            Console.Write(" " + 1 + " |");
            Console.Write(" " + 2 + " ");
            Console.WriteLine();
            Console.Write("----------");
            Console.WriteLine();
            Console.Write(" " + 3 + " |");
            Console.Write(" " + 4 + " |");
            Console.Write(" " + 5 + " ");
            Console.WriteLine();
            Console.Write("----------");
            Console.WriteLine();
            Console.Write(" " + 6 + " |");
            Console.Write(" " + 7 + " |");
            Console.Write(" " + 8 + " ");
            Console.WriteLine();
        }

        public static Move minimax(string[] newBoard, string player)
        {
            int length = (int)Math.Sqrt(newBoard.Length);
            Move result = new Move(); //last move
            List<int> availSpots = new List<int>();
            emptyPlaces(newBoard, availSpots); //list of empty indexes in the board

            if (IsWinning(newBoard, player, length) && player == "O")
            {
                result.SetScore(-10);
                return result;
            }
            if (IsWinning(newBoard, player, length) && player == "X")
            {
                result.SetScore(10);
                return result;
            }
            if (availSpots.Count == 0)
            { 
                result.SetScore(0);
                return result;
            }

            List<Move> moves = new List<Move>();
            //going through the empty indexes and collecting the score and indexes of each move in a list
            for (int i = 0; i < availSpots.Count; i++)
            {
                Move single_move = new Move();
                single_move.SetIndex(availSpots[i]);
                newBoard[availSpots[i]] = player;

                if (player == "X")
                {
                    result = minimax(newBoard, "O");
                    single_move.SetScore(result.GetScore());
                }
                else
                {
                    
                    result = minimax(newBoard, "X");
                    single_move.SetScore(result.GetScore());
                }
                
                newBoard[availSpots[i]] = ""; //reset
               
                moves.Add(single_move);
            }


            int bestMove = 0; //best move index
            if (player == "X")
            {
                int bestScore = -10000;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves[i].GetScore() > bestScore)
                    {
                        bestScore = moves[i].GetScore();
                        bestMove = i;

                    }
                }
            }
            else
            {
                int bestScore = 10000;
                for (int i = 0; i < moves.Count; i++)
                {
                    if (moves[i].GetScore() < bestScore)
                    {
                        bestScore = moves[i].GetScore();
                        bestMove = i;

                    }
                }

            }

            return moves[bestMove]; //returning the best move

        }

        public static void emptyPlaces(string[] board, List<int> indexes)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == "")
                {
                    indexes.Add(i);
                }
            }
        }

        public static bool winning(string[] board, string player)
        {
            if (
                   (board[0] == player && board[1] == player && board[2] == player) ||
                   (board[3] == player && board[4] == player && board[5] == player) ||
                   (board[6] == player && board[7] == player && board[8] == player) ||
                   (board[0] == player && board[3] == player && board[6] == player) ||
                   (board[1] == player && board[4] == player && board[7] == player) ||
                   (board[2] == player && board[5] == player && board[8] == player) ||
                   (board[0] == player && board[4] == player && board[8] == player) ||
                   (board[2] == player && board[4] == player && board[6] == player)
                   )
            {
                return true;
            }
            return false;
        }

        public static bool IsWinning(string[] board, string player, int length)
        {

            int n = (int)Math.Sqrt(board.Length);
            for (int i = 0; i < n; i++)
            {
                if (WinningStreak(board, 0, i, 1, 0, length, player) || WinningStreak(board, i, 0, 0, 1, length, player)) //WIDTH & LENGTH check
                {
                    return true;
                }
            }

            return WinningStreak(board, 0, 0, 1, 1, length, player) || WinningStreak(board, n - 1, 0, -1, 1, length, player); //diagonal check



        }

        public static bool WinningStreak(string[] board, int x, int y, int dx, int dy, int length, string player)
        {
            //WHEN DY = 1, CHECKS DOWNWARDS. WHEN DX = 1, CHECKS RIGHTWARDS. X = COLUMNS, Y = ROWS (X,Y)
            //WHEN DY = 1, DX = 1, CHECKS DIAGONALLY FROM (0,0); WHEN DY = 1, DX = -1, CHECKS DIAGONALLY FROM (N-1,0)

            /*   X X X
             *   ------>
             * Y |
             * Y |
             * Y |
             *   v
             */

            int indexChange = (int)Math.Sqrt(board.Length) * dy + dx;
            int count = 0;
            int depth = 0;
            int index = (int)Math.Sqrt(board.Length) * y + x;
            while (index >= 0 && index < board.Length && depth < length)
            {
                if (board[index] == player)
                {
                    count++;
                }

                if (count == length)
                {
                    return true;
                }
                index += indexChange;
                depth++;
            }
            return false;

        }
    }
}
