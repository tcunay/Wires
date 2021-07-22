using UnityEngine;
using UnityEngine.UI;

namespace WiresGame.UI
{
    public class ChildControlHeightHandler
    {
        private VerticalLayoutGroup _verticalLayoutGroup;
        private RectTransform _rectTransform;

        public ChildControlHeightHandler(VerticalLayoutGroup verticalLayoutGroup)
        {
            _verticalLayoutGroup = verticalLayoutGroup;
            _rectTransform = (RectTransform)_verticalLayoutGroup.transform;
        }

        public void TryEnableChildControlHeight()
        {
            if (IsFull())
                SetChildControlHeight(true);

            UpdateRectTransform();
        }

        private bool IsFull()
        {
            return _verticalLayoutGroup.minHeight > _rectTransform.rect.height;
        }

        private void SetChildControlHeight(bool isControl)
        {
            _verticalLayoutGroup.childControlHeight = isControl;
        }

        private void UpdateRectTransform()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }
    }
}
