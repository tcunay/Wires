using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using WiresGame.Elements;

namespace WiresGame
{
    public class LineViewer : MonoBehaviour
    {
        [SerializeField] private LineRenderer _template;

        private List<LineRenderer> _allLines = new List<LineRenderer>();
        private LineRenderer _currentLine;
        private ElementsConnector _elementsConnector;
        private TouchHandler _touchHandler;
        private Camera _camera;
        private Vector2 _startPoint;
        private Vector2 _endPoint;

        private void OnEnable()
        {
            _camera = Camera.main;
        }

        private void OnDisable()
        {
            _elementsConnector.ElementClicked -= OnBeginRender;
            _elementsConnector.Connected -= OnConected;
            _elementsConnector.ConnectFailed -= ClearLine;
            UnSubscribeFromTouchHandler();
        }

        public void OnDrag(PointerEventData eventData)
        {
            _endPoint = _camera.ScreenToWorldPoint(eventData.position);
            Render();
        }

        public void Init(ElementsConnector elementsConnector)
        {
            Clear();
            SpawnNewLine();
            _elementsConnector = elementsConnector;
            _elementsConnector.ElementClicked += OnBeginRender;
            _elementsConnector.Connected += OnConected;
            _elementsConnector.ConnectFailed += ClearLine;

        }

        private void OnConected()
        {
            DeInitTouchHandler();
            SaveLine();
            SpawnNewLine();
        }

        private void SpawnNewLine()
        {
            _currentLine = Instantiate(_template, transform).GetComponent<LineRenderer>();
        }

        private void SaveLine()
        {
            _allLines.Add(_currentLine);
        }

        private void ClearLine()
        {
            _currentLine.positionCount = 0;

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
            _currentLine.positionCount = positions.Length;
            _currentLine.SetPositions(positions);
        }

        private void OnBeginRender(Element element, PointerEventData eventData)
        {
            SetStartPoint(eventData.position);
            SetColor(element.Color);
            InitTouchHandler(element);
        }

        private void InitTouchHandler(Element element)
        {
            UnSubscribeFromTouchHandler();

            _touchHandler = element.TouchHandler;
            _touchHandler.Draged += OnDrag;
        }

        private void DeInitTouchHandler()
        {
            UnSubscribeFromTouchHandler();
            _touchHandler = null;
        }

        private void UnSubscribeFromTouchHandler()
        {
            if (_touchHandler != null)
                _touchHandler.Draged -= OnDrag;
        }

        private void SetStartPoint(Vector2 position)
        {
            _startPoint = _camera.ScreenToWorldPoint(position);
        }

        private void SetColor(Color color)
        {
            _currentLine.startColor = new Color(color.r, color.g, color.b, _currentLine.startColor.a);
            _currentLine.endColor = new Color(color.r, color.g, color.b, _currentLine.endColor.a);
        }
    }
}
