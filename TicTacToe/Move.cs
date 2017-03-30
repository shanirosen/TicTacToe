using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Move
    {
        private int score;
        private int index;

        public int GetScore()
        {
            return score;
        }
        public int GetIndex()
        {
            return index;
        }

        public void SetScore(int newScore)
        {
            score = newScore;
        }
        public void SetIndex(int newIndex)
        {
            index = newIndex;
        }


    }
}
