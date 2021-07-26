using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

        public Action<Element, PointerEventData> ElementClicked;
        public Action<Element, PointerEventData> ElementEntered;
        public Action<Element, PointerEventData> ElementUped;
        public Action<Element, PointerEventData> ElementExited;

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

            element.Clicked += OnElementClicked;
            element.Entered += OnElementEntered;
            element.Uped += OnElemenetUped;

            _elements.Add(element);
        }

        private void OnElementClicked(Element element, PointerEventData eventData)
        {
            ElementClicked?.Invoke(element, eventData);
        }

        private void OnElementEntered(Element element, PointerEventData eventData)
        {
            ElementEntered.Invoke(element, eventData);
        }

        private void OnElemenetUped(Element element, PointerEventData eventData)
        {
            ElementUped?.Invoke(element, eventData);
        }

        private void OnElementExited(Element element, PointerEventData eventData)
        {
            ElementExited?.Invoke(element, eventData);
        }

        public void SubscribeElementCanseled()
        {
            foreach (var item in _elements)
            {
                item.Uped += ElementUped;
            }
        }
    }
}
