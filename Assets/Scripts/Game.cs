using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;
using WiresGame.UI;

namespace WiresGame
{
    [RequireComponent(typeof(Spawner))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private ElementsConnector _elementsConnector;
        [SerializeField] private RestartPanel _restartPanel;
        [SerializeField] private int _count;

        private Spawner _spawner;

        private void Awake()
        {
            _spawner = GetComponent<Spawner>();
        }

        private void OnEnable()
        {
            _restartPanel.RestartButton.onClick.AddListener(StartGame);
            _restartPanel.ExitButton.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            _restartPanel.RestartButton.onClick.RemoveListener(StartGame);
            _restartPanel.ExitButton.onClick.RemoveListener(Exit);
        }

        private void Start()
        {
            StartGame();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                FillBoards();
        }

        private void FillBoards()
        {
            _elementsConnector.Init(_spawner, _count);
        }

        public void StartLevel(int level)
        {
            FillBoards();
        }

        public void StartGame()
        {
            StartLevel(1);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}
