using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WiresGame.Player;
using System;

namespace WiresGame.TopLists
{
    public class TopListCreator : MonoBehaviour
    {
        [SerializeField] private TopListCell _template;
        [SerializeField] private Transform _createParent;
        [SerializeField] private int _topCount;

        private List<TopListCell> _cells;

        public void Create(List<PlayerStatsData> playerStatsDatas)
        {
            Remove();
            SortList(ref playerStatsDatas);
            int spawnCount = CalculateSpawnCount(playerStatsDatas);

            _cells = new List<TopListCell>();
            for (int i = 0; i < spawnCount; i++)
            {
                TopListCell cell = Instantiate(_template, _createParent);
                cell.Init(playerStatsDatas[i].Name, playerStatsDatas[i].Score);
                _cells.Add(cell);
            }
        }

        private void Remove()
        {
            if (_cells == null)
                return;

            foreach (var item in _cells)
            {
                Destroy(item.gameObject);
            }
        }

        private void SortList(ref List<PlayerStatsData> playerStatsDatas)
        {
            playerStatsDatas.Sort();
        }

        private int CalculateSpawnCount(List<PlayerStatsData> playerStatsDatas)
        {
            if (_topCount > playerStatsDatas.Count)
                return playerStatsDatas.Count;
            else
                return _topCount;
        }
    }
}