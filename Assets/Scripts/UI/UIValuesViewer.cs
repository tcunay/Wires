using UnityEngine;
using System.Collections;
using TMPro;

namespace WiresGame.UI
{
    [System.Serializable]
    public class UIValuesViewer
    {
        [SerializeField] private TMP_Text _text;

        private INeedViewer<int> _iNeedViewr;

        ~UIValuesViewer()
        {
            _iNeedViewr.NeedViewed -= ShowText;
        }

        public void Init(INeedViewer<int> iNeedViewer)
        {
            if (_iNeedViewr != null)
                _iNeedViewr.NeedViewed -= ShowText;

            _iNeedViewr = iNeedViewer;
            _iNeedViewr.NeedViewed += ShowText;
        }

        private void ShowText(int needViewValue)
        {
            _text.text = needViewValue.ToString();
        }
    }
}
