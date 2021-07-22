using UnityEngine;
using UnityEngine.UI;

namespace WiresGame.UI
{
    public class ChildControlHeightHandler
    {
        private VerticalLayoutGroup _verticalLayoutGroup;
        private RectTransform _rectTransform;

        public ChildControlHeightHandler(VerticalLayoutGroup verticalLayoutGroup, RectTransform rectTransform)
        {
            _verticalLayoutGroup = verticalLayoutGroup;
            _rectTransform = rectTransform;
        }

        public void TryEnableChildControlHeight()
        {
            if (IsFull())
                SetChildControlHeight(true);
        }

        private bool IsFull()
        {
            return _verticalLayoutGroup.minHeight > _rectTransform.rect.height;
        }

        private void SetChildControlHeight(bool isControl)
        {
            _verticalLayoutGroup.childControlHeight = isControl;
        }
    }
}
