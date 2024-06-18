using UnityEngine;
using Game.PlayerComponents;

namespace Game.Environment
{
    public class VictoryField : InteractableObject
    {
        protected override void InteractWithPlayer(Player player)
        {
            player.ProcessVictory();
        }
    }
}
