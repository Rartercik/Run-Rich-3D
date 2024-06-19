using System;
using UnityEngine;
using Game.MenuComponents;
using Game.Tools;

namespace Game.PlayerComponents
{
    [Serializable]
    public class PlayerInteraction
    {
        [SerializeField] private MoneyVisualizer _moneyVisualizer;
        [SerializeField] private AnimationClip _spinAnimation;
        [SerializeField] private int _money;
        [SerializeField] private Status[] _statuses;
        [HideInInspector]
        [SerializeField] private int _statusIndex;

        private readonly string _spinKey = "Spin";

        private Animator _animator;
        private Action _onGameOver;

        public int Money => _money;

        public void OnValidate()
        {
            if (_statuses == null || _statuses.Length == 0) return;

            if (_statuses[0].MaxMoney < 1)
            {
                _statuses[0].MaxMoney = 1;
            }
            for (int i = 1; i < _statuses.Length; i++)
            {
                if (_statuses[i].MaxMoney <= _statuses[i - 1].MaxMoney)
                {
                    _statuses[i].MaxMoney = _statuses[i - 1].MaxMoney + 1;
                }
            }

            UpdateStatus(_money);
        }

        public void Initialize(Animator animator, Action onGameOver)
        {
            var maxBarValueIndex = _statuses.Length > 1 ? _statuses.Length - 2 : _statuses.Length - 1;
            _moneyVisualizer.Initialize(_statuses[maxBarValueIndex].MaxMoney + 1, _money);
            _animator = animator;
            _onGameOver = onGameOver;
        }

        public void ChangeMoneyAmount(int change)
        {
            _money += change;
            if (_money < 0)
            {
                _money = 0;
            }

            _moneyVisualizer.SetAmount(_money);
            if (_money == 0)
            {
                _onGameOver?.Invoke();
                return;
            }
            
            UpdateStatus(_money);
        }

        public void UpdateStatus(int money)
        {
            var previousStatusIndex = _statusIndex;
            _statusIndex = 0;
            _statuses[0].Person.Deactivate();
            for (int i = 1; i < _statuses.Length; i++)
            {
                _statuses[i].Person.Deactivate();
                var previousIndex = i - 1;
                if (_statuses[previousIndex].MaxMoney < money)
                {
                    _statusIndex = i;
                }
            }

            if (previousStatusIndex != _statusIndex)
            {
                if (_animator.IsPlaying(_spinAnimation) == false)
                {
                    _animator.SetTrigger(_spinKey);
                }
            }
            _statuses[_statusIndex].Person.Activate();
        }
    }
}