using UnityEngine;
using Game.MenuComponents;

namespace Game.PlayerComponents
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameStarter _gameStarter;
        [SerializeField] private Player _player;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private float _shiftBorders = 3;

        private float _currentPosition;
        private float _previousPosition;
        private bool _isPressed;

        private void Update()
        {
            var mousePosition = Input.mousePosition;
            var mouseX = _camera.ScreenToViewportPoint(mousePosition).x;
            mouseX = (mouseX - 0.5f) * _shiftBorders;

            if (Input.GetMouseButtonDown(0))
            {
                _gameStarter.TryStartGame();
                _currentPosition = _previousPosition = mouseX;
                _isPressed = true;
            }
            else if (_isPressed)
            {
                _currentPosition = mouseX;
                var shift = _currentPosition - _previousPosition;
                _player.MoveAside(shift);
                _previousPosition = _currentPosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isPressed = false;
            }
        }
    }
}
