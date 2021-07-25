using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WiresGame.UI
{
    public class RestartPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;
        [SerializeField] private Button _exit;

        public Button RestartButton => _restart;
        public Button ExitButton => _exit;
    }
}
