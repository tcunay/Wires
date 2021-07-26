using UnityEngine;
using UnityEngine.EventSystems;

namespace WiresGame.Elements
{
    class TransformScaler
    {
        private TouchHandler _touchHandler;
        private Transform _transform;
        private Vector3 _initScale;
        private float _scaleFactor = 1.2f;
        private bool _isScaleFixed = false;

        public TransformScaler(Transform transform, TouchHandler touchHandler)
        {
            _transform = transform;
            _touchHandler = touchHandler;

            _initScale = _transform.localScale;

            _touchHandler.PointerDowned += OnPointerDown;
            _touchHandler.PointerEntered += OnPointerEnter;
            _touchHandler.PointerUped += OnPointerUp;
            _touchHandler.PointerExited += OnPointerExit;
        }

        ~TransformScaler()
        {
            UnSubscribeFromTouchHandler();
        }

        public void StopScaling()
        {
            UnSubscribeFromTouchHandler();
        }

        private void OnPointerDown(PointerEventData eventData)
        {
            Fix();
        }

        private void OnPointerEnter(PointerEventData eventData)
        {
            TryToScale();
        }

        private void OnPointerUp(PointerEventData eventData)
        {
            UnScale();
            UnFix();
        }

        private void OnPointerExit(PointerEventData eventData)
        {
            TryUnScale();
        }

        private void TryToScale()
        {
            if(_isScaleFixed == false)
            _transform.localScale *= _scaleFactor;
        }

        private void UnScale()
        {
            _transform.localScale = _initScale;
        }

        private void TryUnScale()
        {
            if (_isScaleFixed == false)
                UnScale();
        }

        private void Fix()
        {
            SetFixedScale(true);
        }

        private void UnFix()
        {
            SetFixedScale(false);
        }

        private void SetFixedScale(bool isFixed)
        {
            _isScaleFixed = isFixed;
        }

        private void UnSubscribeFromTouchHandler()
        {
            _touchHandler.PointerDowned -= OnPointerDown;
            _touchHandler.PointerEntered -= OnPointerEnter;
            _touchHandler.PointerUped -= OnPointerUp;
            _touchHandler.PointerExited -= OnPointerExit;
        }
    }
}
