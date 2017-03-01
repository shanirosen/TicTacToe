using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             *  0 |   | X
             *  ---------- 
             *  X |   | X
             *  ----------
             *    | 0 | 0
             *  
             */

            string huPlayer = "0";
            string aiPlayer = "X";
            string[] origBoard = new string[9] { "0", null, "X", "X", null, "X", null, "0", "0" };
      

            Move bestSpot = new Move();
            bestSpot = minimax(origBoard, aiPlayer);
            Console.WriteLine(bestSpot.GetScore());

            Console.WriteLine("next move:" +bestSpot.GetIndex());

        }

        public static Move minimax(string[] newBoard, string player)
        {
        
            Move result = new Move(); //last move
            List<int> availSpots = new List<int>();
            emptyPlaces(newBoard, availSpots); //list of empty indexes in the board
            if (winning(newBoard, player) && player == "0")
            {
                Debug.WriteLine("human won");
                result.SetScore(-10);
                return result;
            }
            if (winning(newBoard, player) && player == "X")
            {
                Debug.WriteLine("comp won");
                result.SetScore(10);
                return result;
            }
            if (availSpots.Count == 0)
            {
                Debug.WriteLine("nobody won");
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
                    result = minimax(newBoard, "0");
                    single_move.SetScore(result.GetScore());
                }
                else
                {
                    result = minimax(newBoard, "X");
                    single_move.SetScore(result.GetScore());
                }

                newBoard[availSpots[i]] = null; //reset

                moves.Add(single_move);
                Console.WriteLine("score: " +single_move.GetScore());
                Console.WriteLine("index:" + single_move.GetIndex());
            }

            Console.WriteLine("num of moves: " +moves.Count);
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
                Console.WriteLine("bestmove: " + bestMove);
            Console.WriteLine("num of moves" + moves.Count);
         

                return moves[bestMove]; //returning the best move

        }

        public static void emptyPlaces(string[] board, List<int> indexes)
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == null)
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
    }
}
