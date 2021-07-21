using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;

namespace WiresGame
{
    [RequireComponent(typeof(Spawner))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private Element template;
        private Spawner _spawner;
        private int _count;

        private void Awake()
        {
            _spawner = GetComponent<Spawner>();
        }

        private void OnEnable()
        {
            _spawner.Spawned += OnElementsSpawned;
        }

        private void OnDisable()
        {
            _spawner.Spawned -= OnElementsSpawned;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SpawnElements();
        }

        private void SpawnElements()
        {
            for (int i = 0; i < _count; i++)
            {
                var a = _spawner.Spawn(template);
            }
        }

        private void OnElementsSpawned()
        {

        }
    }
}
