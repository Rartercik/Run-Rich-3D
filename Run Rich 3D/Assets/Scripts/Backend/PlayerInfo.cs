using System;
using UnityEngine;

namespace Backend
{
    [CreateAssetMenu(menuName = "Data/Player Info")]
    public class PlayerInfo : ScriptableObject
    {
        [field: SerializeField] public int Money { get; private set; }

        public void AddMoney(int money)
        {
            if (money < 0) throw new ArgumentException("Money amount must be positive");

            Money += money;
        }
    }
}
