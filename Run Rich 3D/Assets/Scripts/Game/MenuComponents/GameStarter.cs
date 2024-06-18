using UnityEngine;
using ButchersGames;
using Game.PlayerComponents;

namespace Game.MenuComponents
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Canvas _gameOverWindow;
        [SerializeField] private Canvas _victoryWindow;
        [SerializeField] private Canvas[] _enablingWindows;
        [SerializeField] private Canvas[] _disablingWindows;

        private bool _started;

        public void TryStartGame()
        {
            if (_started) return;

            foreach (var canvas in _enablingWindows)
            {
                canvas.enabled = true;
            }
            foreach (var canvas in _disablingWindows)
            {
                canvas.enabled = false;
            }
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
            _gameOverWindow.enabled = true;
        }

        public void ProcessVictory()
        {
            _victoryWindow.enabled = true;
        }
    }
}