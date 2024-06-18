using UnityEngine;

namespace Game.PlayerComponents
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Transform _player;

        private Vector3 _offset;

        private void Start()
        {
            _offset = _transform.position - _player.position;
        }

        private void LateUpdate()
        {
            _transform.position = _player.position + _offset;
        }
    }
}
