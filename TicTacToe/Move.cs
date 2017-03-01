using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Move
    {
        private int score;
        private string index;

        public int GetScore()
        {
            return score;
        }
        public string GetIndex()
        {
            return index;
        }

        public void SetScore(int newScore)
        {
            score = newScore;
        }
        public void SetIndex(string newIndex)
        {
            index = newIndex;
        }


    }
}
