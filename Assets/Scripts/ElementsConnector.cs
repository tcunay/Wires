using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WiresGame.Elements;

namespace WiresGame
{
    [System.Serializable]
    public class ElementsConnector
    {
        [SerializeField] private List<ElementsBoard> _elementsBoards;

        private ElementsSpawner _spawner;
        private Element _fromElement;
        private Element _intoElement;

        public event Action<Element, Element> Conected;
        public event Action<Color, Vector2> ElementClicked;

        ~ElementsConnector()
        {
            UnSubscribeFromBoards();
        }

        public void Init(ElementsSpawner spawner, int elementsCount)
        {
            _spawner = spawner;

            ClearBoards();
            FillBoards(elementsCount);
        }

        private void FillBoards(int elementsCount)
        {
            _spawner.Spawned += OnElementsSpawned;
            _spawner.SpawnElementsInElementConecter(_elementsBoards, elementsCount);
        }

        private void OnElementsSpawned()
        {
            foreach (var item in _elementsBoards)
            {
                item.ElementClicked += OnElementClicked;
                item.ElementEntered += OnElementEntered;
                item.ElementUped += OnElementUped;
                item.ElementExited += OnElementExited;
            }
        }

        private void OnElementClicked(Element element, PointerEventData eventData)
        {
            SetFromElement(element);
            ElementClicked?.Invoke(element.Color, eventData.position);
        }

        private void OnElementEntered(Element element, PointerEventData eventData)
        {
            SetIntoElement(element);
        }

        private void OnElementUped(Element element, PointerEventData eventData)
        {
            TryConnect(element);
        }

        private void OnElementExited(Element element, PointerEventData eventData)
        {
            SetNullElements();
        }

        private void SetNullElements()
        {
            SetFromElement(null);
            SetIntoElement(null);
        }

        private void SetIntoElement(Element element)
        {
            _intoElement = element;
        }

        private void SetFromElement(Element element)
        {
            _fromElement = element;
        }

        private void TryConnect(Element element)
        {
            if (_intoElement == null || _fromElement == null) return;

            if (IsColorsMatch(_intoElement.Color, _fromElement.Color))
            {
                if (IsBoardsMatch(_intoElement.ParentBoard, _fromElement.ParentBoard) == false)
                {
                    ConnectElements();
                }
            }
        }

        private bool IsColorsMatch(Color one, Color two)
        {
            return one == two;
        }

        private bool IsBoardsMatch(ElementsBoard one, ElementsBoard two)
        {
            return one == two;
        }

        private void ConnectElements()
        {
            _intoElement.Connect();
            _fromElement.Connect();

            Conected?.Invoke(_fromElement, _intoElement);
        }

        private void UnSubscribeFromBoards()
        {
            foreach (var item in _elementsBoards)
            {
                item.ElementClicked -= OnElementClicked;
                item.ElementEntered -= OnElementEntered;
                item.ElementUped -= OnElementUped;
            }
        }

        private void ClearBoards()
        {
            UnSubscribeFromBoards();
            foreach (var item in _elementsBoards)
            {
                item.Clear();
            }
        }
    }
}
