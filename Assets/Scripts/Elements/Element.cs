using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WiresGame.Elements
{
    [RequireComponent(typeof(Image))]
    public class Element : MonoBehaviour
    {
        private Image _image;

        public Color Color => _image.color;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void SetColor(Color color)
        {
            _image.color = color;
        }
    }
}
