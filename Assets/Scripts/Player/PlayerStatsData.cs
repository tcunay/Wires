using System;

namespace WiresGame.Player
{
    [System.Serializable]
    public struct PlayerStatsData : IComparable<PlayerStatsData>
    {
        public string Name;
        public int Score;

        public int CompareTo(PlayerStatsData other)
        {
            if (Score < other.Score)
                return 1;
            else if (Score > other.Score)
                return -1;
            else
                return 0;
        }       
    }
}
