using UnityEngine;
using Game.MenuComponents;

namespace Game.PlayerComponents
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private PlayerInteraction _interaction;
        [SerializeField] private GameStarter _gameStarter;

        private readonly string _walkKey = "Walk";
        private readonly string _upsetKey = "Upset";
        private readonly string _danceKey = "Dance";

        private bool _isPlaying;

        public int Money => _interaction.Money;

        private void OnValidate()
        {
            _interaction.OnValidate();
        }

        private void Start()
        {
            _movement.Initialize(_rigidbody);
            _interaction.Initialize(_animator, ProcessGameOver);
        }

        private void FixedUpdate()
        {
            if (_isPlaying == false) return;

            _movement.FixedUpdate();
        }

        public void StartPlaying()
        {
            _animator.SetTrigger(_walkKey);
            _isPlaying = true;
        }

        public void MoveAside(float shift)
        {
            _movement.MoveAside(shift);
        }

        public void ChangeMoneyAmount(int change)
        {
            _interaction.ChangeMoneyAmount(change);
        }

        public void ProcessVictory()
        {
            Stop();
            _animator.SetTrigger(_danceKey);
            _gameStarter.ProcessVictory();
        }

        private void ProcessGameOver()
        {
            Stop();
            _animator.SetTrigger(_upsetKey);
            _gameStarter.ProcessGameOver();
        }

        private void Stop()
        {
            _rigidbody.velocity = Vector3.zero;
            _isPlaying = false;
        }
    }
}
