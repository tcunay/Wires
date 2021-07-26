using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WiresGame.Elements
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(TouchHandler))]
    public class Element : MonoBehaviour
    {
        private TouchHandler _touchHandler;
        private Image _image;
        private TransformScaler _transformScaler;
        private ElementsBoard _parentBoard;

        public Action<Element, PointerEventData> Clicked;
        public Action<Element, PointerEventData> Entered;
        public Action<Element, PointerEventData> Uped;

        public ElementsBoard ParentBoard => _parentBoard;
        public Color Color => _image.color;

        private void Awake()
        {
            _touchHandler = GetComponent<TouchHandler>();
            _image = GetComponent<Image>();
            _transformScaler = new TransformScaler(transform, _touchHandler);

            _touchHandler.PointerDowned += OnClicked;
            _touchHandler.PointerEntered += OnEntered;
            _touchHandler.PointerUped += OnCanseled;
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }

        public void SetParentBoard(ElementsBoard board)
        {
            _parentBoard = board;
        }

        public void Method()
        {
            _transformScaler.StopScaling();
        }

        private void OnClicked(PointerEventData eventData)
        {
            Clicked?.Invoke(this, eventData);
        }

        private void OnEntered(PointerEventData eventData)
        {
            Entered?.Invoke(this, eventData);
        }

        private void OnCanseled(PointerEventData eventData)
        {
            Debug.Log(Color);
            Uped?.Invoke(this, eventData);
        }
    }
}
