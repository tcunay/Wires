using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WiresGame.Elements
{
    public class TouchHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<PointerEventData> PointerDowned;
        public event Action<PointerEventData> PointerEntered;
        public event Action<PointerEventData> PointerUped;
        public event Action<PointerEventData> PointerExited;

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
    }
}
