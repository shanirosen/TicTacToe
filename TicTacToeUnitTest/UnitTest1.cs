using System;
using TicTacToe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToeUnitTest
{
    [TestClass]
    public class TicTacToeUnitTest
    {
        [TestMethod]
        public void TestWinningStreak()
        {
            Assert.IsTrue(Program.WinningStreak(new string[] {
                "X", "", "O", "O",
                "", "", "", "",
                "O", "O", "X", "",
                "O", "X", "", "X"}, 3, 0, -1, 1, 4, "O"));
        }

        [TestMethod]
        public void TestMinimax()
        {
            /*
             *  O | X | O
               -----------
                  | X |
               -----------
                X | O | O
                */

            Move f_move = new Move();
            f_move.SetIndex(5);
            f_move.SetScore(0);
            Assert.Equals(f_move, Program.minimax(new string[] {
                "O", "X" ,"O",
                "", "X", "",
                "X" , "O", "O"
            }, "X")
            );
        }


        [TestMethod]
        public void TestIsWinning()
        {
            Assert.IsTrue(Program.IsWinning(new string[] {
                "X", "X", "O",
                "", "X", "O",
                "X", "O", "O"}, "O", 3));
        }
    }
}
