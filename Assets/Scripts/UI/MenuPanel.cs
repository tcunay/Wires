using UnityEngine;
using UnityEngine.UI;
using TMPro;
using WiresGame.SaveSystems;
using WiresGame.TopLists;

namespace WiresGame.UI
{
    [RequireComponent(typeof(TopListCreator))]
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private GameObject _topList;

        private TopListCreator _topListCreator;
        private ProgressSaver _progressSaver = new ProgressSaver();

        public Button RestartButton => _restart;
        public Button ExitButton => _exit;

        private void Awake()
        {
            _topListCreator = GetComponent<TopListCreator>();
        }

        private void OnEnable()
        {
            _nameInputField.gameObject.SetActive(true);
            _nameInputField.onSubmit.AddListener(InpultFieldOnSelect);
        }

        private void OnDisable()
        {
            _topList.SetActive(false);
            _nameInputField.onSubmit.RemoveListener(InpultFieldOnSelect);
        }

        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
            if (isActive == true)
                ActiveTopList();
        }

        public void SetScore(int score)
        {
            _progressSaver.StatsData.Score = score;

        }

        private void InpultFieldOnSelect(string text)
        {
            _progressSaver.StatsData.Name = text;
            _progressSaver.Save();
            ActiveTopList();
            _nameInputField.text = string.Empty;
        }

        private void ActiveTopList()
        {
            _topListCreator.Create(_progressSaver.GetTopList());
        }
    }
}
