using UnityEngine;
using Game.PlayerComponents;

namespace Game.Environment
{
    public class VictoryField : InteractableObject
    {
        [SerializeField] private ParticleSystem _victoryEffects;

        protected override void InteractWithPlayer(Player player)
        {
            _victoryEffects?.Play();
            player.ProcessVictory();
        }
    }
}
