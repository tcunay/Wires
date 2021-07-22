using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;

namespace WiresGame
{
    [RequireComponent(typeof(Spawner))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private int _count;
        private Spawner _spawner;

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
            _spawner.SpawnElements(_count);
        }

        private void OnElementsSpawned()
        {

        }
    }
}
