﻿using System;

namespace WiresGame
{
    public class DifficultyCalculator
    {
        private int _currentLevel = 0;
        private float _minTimeValue = 10;
        private float _initTimeValue = 30;
        private int _timeCountFactor = 3;
        private int _elementsCountFactor = 1;

        public int CalculateElementsValue(int currentLevel)
        {
            if (currentLevel < 0)
                throw new ArgumentOutOfRangeException();

            return currentLevel * _elementsCountFactor;
        }

        public int CalculateLevelTime(int currentLevel)
        {
            if (currentLevel < 0)
                throw new ArgumentOutOfRangeException();

            return (int)_initTimeValue - _timeCountFactor * currentLevel;
        }
    }
}