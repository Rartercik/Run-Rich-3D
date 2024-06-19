using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ButchersGames;
using Game.PlayerComponents;
using Backend;

namespace Game.MenuComponents
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Canvas _gameOverWindow;
        [SerializeField] private Canvas _victoryWindow;
        [SerializeField] private Image[] _levelImages;
        [SerializeField] private Color _levelImagesColor;
        [SerializeField] private TextMeshProUGUI[] _moneyTexts;
        [SerializeField] private PlayerInfo _playerInfo;
        [SerializeField] private Canvas[] _enablingWindows;
        [SerializeField] private Canvas[] _disablingWindows;
        [SerializeField] private AudioSource _gameOverSound;
        [SerializeField] private AudioSource _victorySound;

        private bool _started;

        private void Start()
        {
            var passedLevels = LevelManager.CurrentLevel % _levelImages.Length;
            for (int i = 0; i <  _levelImages.Length; i++)
            {
                if (i + 1 < passedLevels)
                {
                    _levelImages[i].color = _levelImagesColor;
                }
            }
            SetMoneyTexts(_moneyTexts, _playerInfo.Money);
        }

        public void TryStartGame()
        {
            if (_started) return;

            SetEnabled(_enablingWindows, true);
            SetEnabled(_disablingWindows, false);
            _player.StartPlaying();
            _started = true;
        }

        public void Restart()
        {
            LevelManager.Default.RestartLevel();
        }

        public void ChooseNextLevel()
        {
            LevelManager.Default.NextLevel();
        }

        public void ProcessGameOver()
        {
            SetEnabled(_enablingWindows, false);
            _gameOverSound?.Play();
            _gameOverWindow.enabled = true;
        }

        public void ProcessVictory()
        {
            SetEnabled(_enablingWindows, false);
            _victorySound?.Play();
            _victoryWindow.enabled = true;
            _playerInfo.AddMoney(_player.Money);
            SetMoneyTexts(_moneyTexts, _playerInfo.Money);
        }

        private void SetEnabled(Canvas[] windows, bool enabled)
        {
            foreach (var window in windows)
            {
                window.enabled = enabled;
            }
        }

        private void SetMoneyTexts(TextMeshProUGUI[] texts, int money)
        {
            foreach (var text in texts)
            {
                text.text = money.ToString();
            }
        }
    }
}