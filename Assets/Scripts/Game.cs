using System.Collections.Generic;
using UnityEngine;
using WiresGame.Elements;
using WiresGame.UI;

namespace WiresGame
{
    [RequireComponent(typeof(ElementsSpawner))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private ElementsConnector _elementsConnector;
        [SerializeField] private LineViewer _lineViewer;
        [SerializeField] private RestartPanel _restartPanel;
        [SerializeField] private int _count;

        private ElementsSpawner _spawner;

        private void Awake()
        {
            _spawner = GetComponent<ElementsSpawner>();
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
            _lineViewer.Init(_elementsConnector);
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
