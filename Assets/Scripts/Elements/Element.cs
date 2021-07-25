using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        public ElementsBoard ParentBoard => _parentBoard;
        public Color Color => _image.color;

        private void Awake()
        {
            _touchHandler = GetComponent<TouchHandler>();
            _image = GetComponent<Image>();
            _transformScaler = new TransformScaler(transform, _touchHandler);
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }

        public void SetParentBoard(ElementsBoard board)
        {
            _parentBoard = board;
        }
    }
}
