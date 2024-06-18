using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.MenuComponents
{
    public class MoneyVisualizer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _moneyText;
        [SerializeField] private Image _moneyBar;

        private int _max;

        public void Initialize(int max, int current)
        {
            if (max <= 0) throw new ArgumentException("Max value must be more than 0");

            _max = max;
            SetAmount(current);
        }

        public void SetAmount(int amount)
        {
            _moneyText.text = amount.ToString();
            _moneyBar.fillAmount = (float)amount / _max;
        }
    }
}