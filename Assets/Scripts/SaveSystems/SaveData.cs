using System.Collections.Generic;
using WiresGame.Player;

namespace WiresGame.SaveSystems
{
    [System.Serializable]
    public class SaveData
    {
        public List<PlayerStatsData> PlayerStatsDatas = new List<PlayerStatsData>();
    }
}
