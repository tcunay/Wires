using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WiresGame.Elements
{
    public class TouchHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event Action<PointerEventData> PointerDowned;
        public event Action<PointerEventData> PointerEntered;
        public event Action<PointerEventData> PointerUped;
        public event Action<PointerEventData> PointerExited;
        public event Action<PointerEventData> Draged;

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDowned?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEntered?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUped?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExited?.Invoke(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Draged?.Invoke(eventData);
        }
    }
}
