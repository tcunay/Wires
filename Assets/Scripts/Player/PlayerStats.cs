using UnityEngine;
using System.Collections;
using System;

namespace WiresGame.Player
{
    public class PlayerStats
    {
        private string _name;
        private int _score;

        public int Score => _score;

        public void AddScore(int score)
        {
            if (score < 0)
                new ArgumentOutOfRangeException(nameof(score) + " < 0");

            _score += score;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}
