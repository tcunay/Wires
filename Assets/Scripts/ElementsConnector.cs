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

        private Spawner _spawner;
        private Element _fromElement;
        private Element _intoElement;

        ~ElementsConnector()
        {
            UnSubscribeFromBoards();
        }

        public void Init(Spawner spawner, int elementsCount)
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
                item.ElementClicked += SetFromElement;
                item.ElementEntered += SetIntoElement;
                item.ElementUped += TryConnect;
                item.ElementExited += SetNullIntoElement;
            }
        }

        private void SetNullIntoElement(Element element, PointerEventData eventData)
        {
            _intoElement = null;
        }

        private void SetIntoElement(Element element, PointerEventData eventData)
        {
            _intoElement = element;
        }

        private void SetFromElement(Element element, PointerEventData eventData)
        {
            _fromElement = element;
        }

        private void TryConnect(Element element, PointerEventData eventData)
        {
            if (_intoElement == null || _fromElement == null) return;

            if(IsColorsMatch(_intoElement.Color, _fromElement.Color) && IsBoardsMatch(_intoElement.ParentBoard, _fromElement.ParentBoard) == false)
                ConnectElements();
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
            Debug.Log("Connect");
            _intoElement.Connect();
            _fromElement.Connect();
        }

        private void UnSubscribeFromBoards()
        {
            foreach (var item in _elementsBoards)
            {
                item.ElementClicked -= SetFromElement;
                item.ElementEntered -= SetIntoElement;
                item.ElementUped -= TryConnect;
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
