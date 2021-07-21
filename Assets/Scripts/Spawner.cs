using System;
using UnityEngine;

namespace WiresGame
{

    class Spawner : MonoBehaviour
    {
        public event Action Spawned;

        public T Spawn<T>(T template) where T: UnityEngine.Object
        {
            return Instantiate(template);
        }
    }
}
