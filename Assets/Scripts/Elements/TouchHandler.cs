using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WiresGame.Elements
{
    class TouchHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<PointerEventData> PointerDowned;
        public event Action<PointerEventData> PointerEntered;
        public event Action<PointerEventData> PointerUped;
        public event Action<PointerEventData> PointerExited;

        public void OnPointerDown(PointerEventData eventData)
        {
            PointerDowned?.Invoke(eventData);
            //_isScaleFixed = true;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEntered?.Invoke(eventData);
            //transform.localScale *= _scaleFactor;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PointerUped?.Invoke(eventData);
            //transform.localScale = _initLocalScale;
            //_isScaleFixed = false;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExited?.Invoke(eventData);
            //if(_isScaleFixed == false)
            //transform.localScale = _initLocalScale;
        }
    }
}
