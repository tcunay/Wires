using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawLine : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Canvas _canvas;

    private Vector2 _startPoint;
    private Vector2 _endPoint;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPoint = Camera.main.ScreenToWorldPoint(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _endPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        Render();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
    }

    private void Render()
    {
        Vector3[] positions = { _startPoint, _endPoint };
        _lineRenderer.SetPositions(positions);
    }
}
