namespace WiresGame.SaveSystems
{
    public interface ISaveSystem
    {
        void Save(SaveData data);

        SaveData Load();
    }
}
