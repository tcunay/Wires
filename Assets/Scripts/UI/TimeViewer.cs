using UnityEngine;
using System.Collections;
using TMPro;

namespace WiresGame.UI
{
    [System.Serializable]
    public class TimeViewer
    {
        [SerializeField] private TMP_Text _text;

        private Timer _timer;

        ~TimeViewer()
        {
            _timer.TimeTicked -= ShowText;
        }

        public void Init(Timer timer)
        {
            if (_timer != null)
                _timer.TimeTicked -= ShowText;

            _timer = timer;
            _timer.TimeTicked += ShowText;
        }

        private void ShowText(int timeValue)
        {
            _text.text = timeValue.ToString();
        }
    }
}
