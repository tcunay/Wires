using System.Collections.Generic;
using WiresGame.Player;

namespace WiresGame.SaveSystems
{
    public class ProgressSaver
    {
        private SaveData _saveData;
        private ISaveSystem _saveSystem;

        public PlayerStatsData StatsData;

        public void Save()
        {
            _saveData = new SaveData();
            _saveSystem = new BinarySaveSystem();
            _saveData = _saveSystem.Load();
            _saveData.PlayerStatsDatas.Add(StatsData);
            _saveSystem.Save(_saveData);
        }

        public List<PlayerStatsData> GetTopList()
        {
            _saveSystem = new BinarySaveSystem();
            return _saveSystem.Load().PlayerStatsDatas;
        }
    }
}
