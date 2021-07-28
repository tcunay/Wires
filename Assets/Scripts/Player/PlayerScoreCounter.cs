using UnityEngine;
using System.Collections;
using System;

namespace WiresGame.Player
{
    public class PlayerScoreCounter
    {
        private int _score;

        public int Score => _score;

        public void AddScore(int score)
        {
            if (score < 0)
                new ArgumentOutOfRangeException();

            _score += score;
        }
    }
}
