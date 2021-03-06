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
        [SerializeField] private MenuPanel _menuPanel;
        [SerializeField] private GameObject _gamePanel;
        [SerializeField] private UIValuesViewer _timeViewer;
        [SerializeField] private UIValuesViewer _scoreViewer;

        private const int _startLevel = 1;

        private Timer _timer;
        private ElementsSpawner _spawner;
        private DifficultyCalculator _difficultyCalculator = new DifficultyCalculator();
        private PlayerStats _playerStats;
        private int _currentLevel = _startLevel;

        private void Awake()
        {
            _spawner = GetComponent<ElementsSpawner>();
        }

        private void OnEnable()
        {
            _menuPanel.RestartButton.onClick.AddListener(StartGame);
            _menuPanel.ExitButton.onClick.AddListener(Exit);

            _elementsConnector.Finished += NextLevel;
        }

        private void OnDisable()
        {
            _menuPanel.RestartButton.onClick.RemoveListener(StartGame);
            _menuPanel.ExitButton.onClick.RemoveListener(Exit);

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

        private void StartLevel(int level)
        {
            InitTimer(level);
            FillBoards();
            _lineViewer.Init(_elementsConnector);
        }

        private void StartGame()
        {
            ToglePanels(true);

            _playerStats = new PlayerStats(_elementsConnector);
            _currentLevel = _startLevel;

            StartLevel(_currentLevel);
        }

        private void GameOver()
        {
            StopLevel();
            ToglePanels(false);
            _menuPanel.SetScore(_playerStats.StatsData.Score);
        }

        private void StopLevel()
        {
            _timer.StopTick();
            _timer.TickEnded -= GameOver;
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

        private void InitTimer(int level)
        {
            if (_timer != null)
                _timer.TickEnded -= GameOver;

            _timer = new Timer();
            _timer.TickEnded += GameOver;
            _timeViewer.Init(_timer);
            _scoreViewer.Init(_playerStats);
            StartCoroutine(_timer.StartCountdown(_difficultyCalculator.CalculateLevelTime(level)));
        }

        private void ToglePanels(bool isGamePanelActive)
        {
            _gamePanel.SetActive(isGamePanelActive);
            _menuPanel.SetActive(isGamePanelActive == false);
        }
    }
}
