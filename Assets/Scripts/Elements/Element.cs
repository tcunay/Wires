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
        public Action<Element, PointerEventData> Exited;

        public ElementsBoard ParentBoard => _parentBoard;
        public TouchHandler TouchHandler => _touchHandler;
        public Color Color => _image.color;

        private void Awake()
        {
            _touchHandler = GetComponent<TouchHandler>();
            _image = GetComponent<Image>();
            _transformScaler = new TransformScaler(transform, _touchHandler);

            _touchHandler.PointerDowned += OnClicked;
            _touchHandler.PointerEntered += OnEntered;
            _touchHandler.PointerUped += OnCanseled;
            _touchHandler.PointerExited += OnExited;
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }

        public void SetParentBoard(ElementsBoard board)
        {
            _parentBoard = board;
        }

        public void Connect()
        {
            _transformScaler.OnConnect();
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
            Uped?.Invoke(this, eventData);
        }

        private void OnExited(PointerEventData eventData)
        {
            Exited?.Invoke(this, eventData);
        }
    }
}
