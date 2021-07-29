using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace WiresGame.SaveSystems
{
    public class BinarySaveSystem : ISaveSystem
    {
        private readonly string _filePath;
        private readonly string _fileName;

        public BinarySaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Saves";
            _fileName = "/GameSave.save";
        }

        public void Save(SaveData data)
        {
            TryCreateFolder();

            using (FileStream file = File.Create(_filePath + _fileName))
            {
                new BinaryFormatter().Serialize(file, data);
            }
        }

        public SaveData Load()
        {
            SaveData saveData = new SaveData();
            if (File.Exists(_filePath + _fileName) == false)
                Save(saveData);

            using (FileStream file = File.Open(_filePath + _fileName, FileMode.OpenOrCreate))
            {
                object loadedData = new BinaryFormatter().Deserialize(file);
                saveData = (SaveData)loadedData;
            }
            return saveData;
        }

        private void TryCreateFolder()
        {
            if (Directory.Exists(_filePath) == false)
            {
                Directory.CreateDirectory(_filePath);
            }
        }
    }
}
