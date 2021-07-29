using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace WiresGame.UI
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private GameObject _topList;

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

        private void InpultFieldOnSelect(string text)
        {
            _nameInputField.text = string.Empty;
        }

        private void ActiveTopList()
        {

        }


    }
}
