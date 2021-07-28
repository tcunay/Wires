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

        public event Action Connected;
        public event Action Finished;
        public event Action ConnectFailed;
        public event Action<Element, PointerEventData> ElementClicked;

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

        public void Stop()
        {
            UnSubscribeFromBoards();
        }

        private void FillBoards(int elementsCount)
        {
            _spawner.Spawned += OnElementsSpawned;
            _spawner.SpawnElementsInElementsBoards(_elementsBoards, elementsCount);
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
            ElementClicked?.Invoke(element, eventData);
        }

        private void OnElementEntered(Element element, PointerEventData eventData)
        {
            SetIntoElement(element);
        }

        private void OnElementUped(Element element, PointerEventData eventData)
        {
            TryConnect();
        }

        private void OnElementExited(Element element, PointerEventData eventData)
        {
            SetNullElements();
        }

        private void SetNullElements()
        {
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

        private void TryConnect()
        {
            if (_fromElement != null && _intoElement != null)
            {
                if (IsColorsMatch(_fromElement.Color, _intoElement.Color))
                {
                    if (IsBoardsMatch(_fromElement.ParentBoard, _intoElement.ParentBoard) == false)
                    {
                        ConnectElements();
                        return;
                    }
                }
            }
            ConnectFailed?.Invoke();
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

            TrySendFinishMessage();
            Connected?.Invoke();
        }

        private void TrySendFinishMessage()
        {
            if (HaveFreeElements() == false)
                Finished?.Invoke();
        }

        private bool HaveFreeElements()
        {
            foreach (var item in _elementsBoards)
            {
                if (item.HaveFreeElements() == true) return true;
            }
            return false;
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
