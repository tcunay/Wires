using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WiresGame
{
    public class LineViewer : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private LineRenderer _template;

        private List<LineRenderer> _allLines = new List<LineRenderer>();
        private LineRenderer _currentLine;
        private ElementsConnector _elementsConnector;

        private Vector2 _startPoint;
        private Vector2 _endPoint;

        private void OnDisable()
        {
            _elementsConnector.ElementClicked -= OnBeginRender;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //_startPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _endPoint = Camera.main.ScreenToWorldPoint(eventData.position);
            Render();
        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }

        public void Init(ElementsConnector elementsConnector)
        {
            Clear();
            _currentLine = Instantiate(_template, transform).GetComponent<LineRenderer>();
            _elementsConnector = elementsConnector;
            _elementsConnector.ElementClicked += OnBeginRender;

        }

        private void Clear()
        {
            foreach (var item in _allLines)
            {
                Destroy(item.gameObject);
            }
            _allLines = new List<LineRenderer>();
        }

        private void Render()
        {
            Vector3[] positions = { _startPoint, _endPoint };
            _currentLine.SetPositions(positions);
        }

        private void OnBeginRender(Color color, Vector2 position)
        {
            SetStartPoint(position);
            SetColor(color);
            Render();
        }

        private void SetStartPoint(Vector2 position)
        {
            _startPoint = Camera.main.ScreenToWorldPoint(position);
        }

        private void SetColor(Color color)
        {
            _currentLine.material.color = new Color(color.r, color.g, color.b, _currentLine.material.color.a);
        }
    }
}
