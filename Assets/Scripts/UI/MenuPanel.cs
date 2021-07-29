using UnityEngine;
using UnityEngine.UI;
using TMPro;
using WiresGame.Player;
using WiresGame.SaveSystems;
using System.Collections.Generic;

namespace WiresGame.UI
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private GameObject _topList;

        private ISaveSystem _saveSystem;
        private SaveData _saveData;

        public Button RestartButton => _restart;
        public Button ExitButton => _exit;

        private void OnEnable()
        {
            _nameInputField.gameObject.SetActive(true);
            _nameInputField.onSubmit.AddListener(InpultFieldOnSelect);
        }

        private void OnDisable()
        {
            _topList.SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SaveProgress(PlayerStatsData statsData)
        {
            _saveData = new SaveData();
            _saveSystem = new BinarySaveSystem();
            _saveData.PlayerStatsDatas.Add(statsData);
            _saveSystem.Save(_saveData);
        }

        private void InpultFieldOnSelect(string text)
        {
            _nameInputField.text = string.Empty;
        }

        private void ActiveTopList()
        {

        }


    }
}
