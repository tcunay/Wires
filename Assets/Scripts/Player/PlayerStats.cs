using UnityEngine;
using System.Collections;
using System;

namespace WiresGame.Player
{
    public class PlayerStats : INeedViewer<int>
    {
        private ElementsConnector _elementsConnector;
        private PlayerStatsData _statsData;

        public event Action<int> NeedViewed;

        public PlayerStatsData StatsData => _statsData;

        public PlayerStats(ElementsConnector elementsConnector)
        {
            _elementsConnector = elementsConnector;
            _elementsConnector.Connected += AddScore;
        }

        ~PlayerStats()
        {
            _elementsConnector.Connected -= AddScore;
        }

        private void AddScore()
        {
            _statsData.Score++;
            NeedViewed?.Invoke(_statsData.Score);
        }

        public void SetName(string name)
        {
            _statsData.Name = name;
        }
    }
}
