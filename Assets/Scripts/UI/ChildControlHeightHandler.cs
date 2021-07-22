using UnityEngine;
using UnityEngine.UI;

namespace WiresGame.UI
{
    [RequireComponent(typeof(VerticalLayoutGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class ChildControlHeightHandler : MonoBehaviour
    {
        private VerticalLayoutGroup _verticalLayoutGroup;
        private RectTransform _rectTransform;

        private void Awake()
        {
            _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            TryEnableChildControlHeight();
        }

        private void TryEnableChildControlHeight()
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
