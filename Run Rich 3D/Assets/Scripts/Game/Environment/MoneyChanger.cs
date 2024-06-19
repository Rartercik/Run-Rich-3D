using UnityEngine;
using Game.PlayerComponents;

namespace Game.Environment
{
    public class MoneyChanger : InteractableObject
    {
        [SerializeField] private GameObject _deletingObject;
        [SerializeField] private ParticleSystem _particles;
        [SerializeField] private AudioSource _sound;
        [SerializeField] private int _changingAmount;

        protected override void InteractWithPlayer(Player player)
        {
            player.ChangeMoneyAmount(_changingAmount);
            _deletingObject?.SetActive(false);
            _particles?.Play();
            _sound?.Play();
        }
    }
}
