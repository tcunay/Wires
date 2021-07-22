using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WiresGame.UI;

namespace WiresGame.Elements
{
    [RequireComponent(typeof(VerticalLayoutGroup))]
    [RequireComponent(typeof(RectTransform))]
    public class ElementsBoard : MonoBehaviour
    {
        private List<Element> _elements = new List<Element>();
        private VerticalLayoutGroup _verticalLayoutGroup;
        private RectTransform _rectTransform;
        private ChildControlHeightHandler _childControlHeightHandler;

        private void Awake()
        {
            _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            _rectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _childControlHeightHandler = new ChildControlHeightHandler(_verticalLayoutGroup);
        }

        public void AddElement(Element element)
        {
            _childControlHeightHandler.TryEnableChildControlHeight();
            element.SetParentBoard(this);
            _elements.Add(element);
        }
    }
}
