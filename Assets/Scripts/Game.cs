using UnityEngine;
using WiresGame.UI;
using WiresGame.Player;

namespace WiresGame
{
    [RequireComponent(typeof(ElementsSpawner))]
    public class Game : MonoBehaviour
    {
        [SerializeField] private ElementsConnector _elementsConnector;
        [SerializeField] private LineViewer _lineViewer;
        [SerializeField] private RestartPanel _restartPanel;

        private Timer _timer = new Timer();
        private ElementsSpawner _spawner;
        private DifficultyCalculator _difficultyCalculator = new DifficultyCalculator();
        private PlayerStats _playerStats = new PlayerStats();
        private int _currentLevel = 1;

        private void Awake()
        {
            _spawner = GetComponent<ElementsSpawner>();
        }

        private void OnEnable()
        {
            _restartPanel.RestartButton.onClick.AddListener(StartGame);
            _restartPanel.ExitButton.onClick.AddListener(Exit);

            _elementsConnector.Finished += NextLevel;
            _timer.TickEnded += GameOver;
        }

        private void OnDisable()
        {
            _restartPanel.RestartButton.onClick.RemoveListener(StartGame);
            _restartPanel.ExitButton.onClick.RemoveListener(Exit);

            _elementsConnector.Finished -= NextLevel;
            _timer.TickEnded -= GameOver;
        }

        private void Start()
        {
            StartGame();
        }

        private void NextLevel()
        {
            _currentLevel++;
            StartLevel(_currentLevel);
        }

        public void StartLevel(int level)
        {
            StartCoroutine(_timer.StartCountdown(_difficultyCalculator.CalculateLevelTime(level)));

            FillBoards();
            _lineViewer.Init(_elementsConnector);
        }

        public void StartGame()
        {
            StartLevel(_currentLevel);
        }

        private void GameOver()
        {
            StopLevel();
        }

        private void StopLevel()
        {
            _timer.StopTick();
            _elementsConnector.Stop();
        }

        public void Exit()
        {
            Application.Quit();
        }

        private void FillBoards()
        {
            _elementsConnector.Init(_spawner, _difficultyCalculator.CalculateElementsValue(_currentLevel));
        }
    }
}
