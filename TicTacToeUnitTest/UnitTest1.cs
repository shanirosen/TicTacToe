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
        public void TestIsWinning()
        {
            Assert.IsTrue(Program.IsWinning(new string[] {
                "X", "O", "", "",
                "X", "O", "", "O",
                "", "O", "", "O",
                "X", "O", "", "X"}, "O", 4));
        }
    }
}
